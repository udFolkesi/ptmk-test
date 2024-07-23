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
            
            switch (param)
            {
                case 0:
                    break;
                default:
                    Console.WriteLine("Wrong parameter");
                    break;
            }
        }
    }
}