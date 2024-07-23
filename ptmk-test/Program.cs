using System.Diagnostics;

namespace ptmk_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("No parameters entered");
                return;
            }

            int param = Convert.ToInt32(args[0]);
            Database dataBase = new Database();

            switch (param)
            {
                case 1:
                    dataBase.CreateTable();
                    break;
                case 2:
                    if(args.Length != 4)
                    {
                        Console.WriteLine("Wrong parameters");
                        return;
                    }

                    Employee employee = new Employee(args[1], DateTime.Parse(args[2]), args[3]);
                    dataBase.InsertEmployee(employee);
                    break;
                case 3:
                    var employees = dataBase.GetAllEmployees();
                    foreach(var emp in employees)
                    {
                        Console.WriteLine($"{emp.FullName} {emp.BirthDate} {emp.Sex} {emp.GetAge()}");
                    }
                    break;
                case 4:
                    dataBase.GenerateEmployees();
                    break;
                case 5:
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    var employees2 = dataBase.GetSpecialEmployees();
                    stopwatch.Stop();
                    foreach (var emp in employees2)
                    {
                        Console.WriteLine($"{emp.FullName} {emp.BirthDate.ToString("M-dd-yyyy")} {emp.Sex} {emp.GetAge()}");
                    }

                    Console.WriteLine($"Time wasted: {stopwatch.Elapsed}");
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Wrong parameter");
                    break;
            }
        }
    }
}