using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Methods_007_0
{
    class Program
    {
        static public void Calculate(int x, int y, int z)
        {
            Console.WriteLine("avarage is:{0}", (x + y + z) / 3);
        }

        static void Main(string[] args)
        {
            Calculate(2,6,8);
        }
    }
}
