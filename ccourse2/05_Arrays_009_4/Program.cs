using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Arrays_009_4
{
    class Program
    {

        public static void PrintArr(int[] arr)
        {
            Console.WriteLine("Printing arr:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(" " + arr[i]);
            }
            Console.Write("\n");
        }
        public static int[] ExtendArr(int[] inarr, int addint)
        {
            int[] outarr = new int[inarr.Length + 1];
            outarr[0] = addint;
            for (int i = 1; i < outarr.Length; i++)
            {
                outarr[i] = inarr[i - 1];
            }

            return outarr;
        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };

            PrintArr(arr);

            PrintArr(ExtendArr(arr, 8));

            Console.ReadKey();
        }
    }
}
