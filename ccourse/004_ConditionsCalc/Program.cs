using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_ConditionsCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator. Enter two numbers, then oparetion (*,/,+,-)");

            Console.Write("Enter first number:");
            int num1 = 0;
            int.TryParse(Console.ReadLine(), out num1);

            Console.Write("Enter second number:");
            int num2 = 0;
            int.TryParse(Console.ReadLine(), out num2);

            Console.Write("Enter oparetion (*,/,+,-):");
            string operetion = Console.ReadLine();

            double result = 0;
            switch (operetion)
            {
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        result = 0;
                        Console.WriteLine("For '/' second number should not be 0");
                    }
                    else
                    {
                        result = (double)num1 / num2;
                    }
                    break;
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
            }

            Console.WriteLine("Result of {0} {1} {2} is {3}", num1, operetion, num2, result);
            Console.ReadKey();

        }
    }
}
