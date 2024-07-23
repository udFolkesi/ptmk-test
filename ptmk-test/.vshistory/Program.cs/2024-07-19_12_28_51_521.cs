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

            //int param = Convert.ToInt32(args[0]);
            int param = 1;
            Database dataBase = new Database();

            switch (param)
            {
                case 1:
                    dataBase.CreateTable();
                    break;
                case 2:
                    break;
                case 3:
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