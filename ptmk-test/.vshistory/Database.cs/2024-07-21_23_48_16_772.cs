using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptmk_test
{
    internal class Database
    {
        private string connectionString = @"Server=DESKTOP-C6I6F3P\SQLEXPRESS;Database=ptmk-test;Integrated Security=True;TrustServerCertificate=True";
        private Random random = new Random();

        public void CreateTable()
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(
                    "CREATE TABLE Employees (" +
                    "Id INT PRIMARY KEY IDENTITY," +
                    "FullName NVARCHAR(100)," +
                    "BirthDate DATE," +
                    "Sex NVARCHAR(10))", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Table created.");
            }
        }

        public void InsertEmployee(Employee employee)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(
                    "INSERT INTO Employees (FullName, BirthDate, Sex)" +
                    "VALUES (@FullName, @BirthDate, @Sex)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("FullName", employee.FullName);
                sqlCommand.Parameters.AddWithValue("BirthDate", employee.BirthDate);
                sqlCommand.Parameters.AddWithValue("Sex", employee.Sex);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Row inserted.");
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Employees", sqlConnection);
                ReadRows(sqlCommand, ref employees);
            }

            employees = employees
                .DistinctBy(e => e.FullName)
                .DistinctBy(e => e.BirthDate)
                .OrderBy(e => e.FullName)
                .ToList();
            return employees;
        }

        public void GenerateEmployees()
        {
            string[] names = { "Aleksandr", "Boris", "Vladimir", "Ivan", "Maksim", "Oleg", "Pavel" };
            string[] surnames = { "Fisher", "Williams", "Jones", "Smith"};
            string[] patronymics = { "Fisher", "Williams", "Jones", "Smith" };
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                for(int i = 0;  i < 100; i++)
                {
                    string fullName = $"{names[random.Next(0, names.Length)]} {surnames[random.Next(0, surnames.Length)]} " +
                        $"{patronymics[random.Next(0, patronymics.Length)]}";
                    Employee employee = new Employee(fullName, RandomDate(), random.Next(2) == 0 ? "Male" : "Female");
                    InsertEmployee(employee);
                }
            }

            DateTime RandomDate()
            {
                DateTime start = new DateTime(1950, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(random.Next(range));
            }
        }

        public List<Employee> GetSpecialEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Stopwatch stopwatch = new Stopwatch();
            using(SqlConnection  sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Employees e" +
                    "WHERE Sex='Male' AND e.FullName LIKE 'F%'", sqlConnection);
                ReadRows(sqlCommand, ref employees);
            }

            stopwatch.Start();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            return employees;
        }

        private List<Employee> ReadRows(SqlCommand sqlCommand, ref List<Employee> employees)
        {
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Employee employee = new Employee(
                        reader.GetString(1),
                        reader.GetDateTime(2),
                        reader.GetString(3));
                    employees.Add(employee);
                }
            }

            return employees;
        }
    }
}
