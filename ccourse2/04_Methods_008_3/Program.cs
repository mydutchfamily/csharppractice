using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Methods_008_3
{
    class Program
    {
        public static int Factorial(int x) {
            if (x == 1)
            {
                return x;
            }
            else {
                return x * Factorial(x-1);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Factorial of 5 is: {0}", Factorial(5));
            Console.ReadKey();
        }
    }
}
