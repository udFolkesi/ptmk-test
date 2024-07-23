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
                    break;
                case 5:
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