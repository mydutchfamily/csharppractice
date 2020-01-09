using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Arrays_009_0
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            Console.Write("array revers:");
            for (int i = arr.Length-1; i >= 0; i--)
            {
                Console.Write(" " + arr[i]);
            }

            Console.ReadKey();
        }
    }
}
