using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Arrays_009_3
{
    class Program
    {

        public static int[] MyReverse(int[] inarr)
        {
            int[] outarr = new int[inarr.Length];
            for (int @out = inarr.Length - 1, @in = 0; @out >= 0; @out--, @in++)
            {
                outarr[@in] = inarr[@out];
            }

            return outarr;
        }

        public static void PrintArr(int[] arr)
        {
            Console.WriteLine("Printing arr:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(" " + arr[i]);
            }
            Console.Write("\n");
        }

        public static int[] SubArray(int[] inarr, int index, int count)
        {
            int[] outarr = new int[count];
            for (int @in = 0, @out = index; @in < count; @in++, @out++)
            {
                if (@out < inarr.Length)
                {
                    outarr[@in] = inarr[@out];
                }
                else
                {
                    outarr[@in] = 1;
                }
            }
            return outarr;
        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            PrintArr(arr);

            PrintArr(MyReverse(arr));

            PrintArr(SubArray(arr, 0, 5));

            PrintArr(SubArray(arr, 4, 5));

            PrintArr(SubArray(arr, 0, 10));

            Console.ReadKey();
        }
    }
}
