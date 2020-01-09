using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_Loops_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter numbrer of clients to deliver");
            string numStr = Console.ReadLine();
            int numInt = 0;
            Int32.TryParse(numStr, out numInt);

            int delivery = 1;
            for (int i = 1; i <= numInt; i++)
            {
                delivery = i * delivery;
            }

            Console.WriteLine("there are {0} ways to do delivery", delivery);
            Console.ReadKey();

        }
    }
}
