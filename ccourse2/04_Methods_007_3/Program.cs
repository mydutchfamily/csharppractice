using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Methods_007_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To convert currency enter: currency amount and fx rate");
            Console.Write("currency amount: ");

            double amount = 0;
            Double.TryParse(Console.ReadLine(), out amount);

            Console.Write("fx rate: ");

            double rate = 0;
            Double.TryParse(Console.ReadLine(), out rate);

            Console.WriteLine("amount * fx rate: {0}", amount*rate);
            Console.ReadKey();
        }
    }
}
