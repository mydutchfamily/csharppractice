using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Methods_007_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number to analyze:");

            int input;
            if (Int32.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Number is {0}", 0 <= input ? "positive" : "negative");
                Console.WriteLine("Number is {0} prime", IsPrime(input) ? "" : "not");
            }
            else
            {
                Console.WriteLine("Invalid number");
            };

            Console.ReadKey();
        }

        private static Boolean IsPrime(int input)
        {
            Boolean isPrime = true;
            for (int i = 2; i <= input / 2; i++)
            {
                if (0 == input % i)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }
    }
}
