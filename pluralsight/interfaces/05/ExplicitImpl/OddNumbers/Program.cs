using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Odd Numbers");

            var generator = new OddGenerator();
            foreach (var odd in generator)
            {
                if(odd > 50) 
                    break;
                Console.WriteLine(odd);
            }

            Console.Read();
        }
    }
}
