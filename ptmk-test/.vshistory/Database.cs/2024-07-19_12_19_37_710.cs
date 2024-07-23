using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptmk_test
{
    internal class Database
    {
        private string connectionString = @"Server=DESKTOP-C6I6F3P\\SQLEXPRESS;Database=ptmk-test;Trusted_Connection=True;";

        public void CreateTable()
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(
                    "CREATE TABLE Employees (" +
                    "Id INT PRIMARY KEY IDENTITY" +
                    "FullName NVARCHAR(100)" +
                    "BirthDate DATE" +
                    "Sex NVARCHAR(10))", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Table created.");
            }
        }
    }
}
