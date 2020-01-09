using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_Loops_FromAtoB1
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintAllSumOf(2, 5);

            Event(2, 5);

            Console.ReadKey();
        }

        private static void Event(int a, int b)
        {
            Console.WriteLine("Even numbers from {0} to {1}", a, b);
            for (int i = a; i <= b; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(" {0}", i);
                }
            }
        }

        private static void PrintAllSumOf(int a, int b)
        {
            for (int ai = 1; ai <= a; ai++)
            {
                for (int bi = 1; bi <= b; bi++)
                {
                    Console.WriteLine("sum of {0} + {1} = {2}", ai, bi, (ai + bi));
                }
            }
        }
    }
}
