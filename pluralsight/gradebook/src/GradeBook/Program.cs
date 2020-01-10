using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 34.1;
            double y = 10.3;
            var result = x + y;

            var numbers = new double[3];

            System.Console.WriteLine(result);

            if (args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]}!");
            }
            else
            {
                Console.WriteLine($"Hello!");
            }
        }
    }
}
