using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_Methods_Calculate
{
    class Program
    {

        static int[] Calculate(int[] nums)
        {
            int[] outNums = nums;

            for (int i = 0; i < nums.Length; i++)
            {
                outNums[i] = nums[i] / 5;
            }

            return outNums;
        }

        static void PrintArr(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n");
        }

        static void Main(string[] args)
        {
            int[] arr = { 10, 15, 30 };
            Console.WriteLine("Input:");
            PrintArr(arr);
            
            Console.WriteLine("output:");
            PrintArr(Calculate(arr));

            Console.ReadKey();
        }
    }
}
