using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Arrays_009_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrSize = 0;
            Console.WriteLine("Enter array size:");
            if (Int32.TryParse(Console.ReadLine(), out arrSize))
            {
                int maxVal = 0, minVal = 0, sumArr = 0, evenIx = 0;
                int[] arr = new int[arrSize];
                int[] even = new int[arrSize];
                Random random = new Random();
                for (int i = 0; i < arrSize; i++)
                {
                    arr[i] = random.Next(0, arrSize);

                    maxVal = maxVal < arr[i] ? arr[i] : maxVal;
                    minVal = minVal > arr[i] ? arr[i] : minVal;
                    sumArr = sumArr + arr[i];

                    if (arr[i] % 2 == 0)
                    {
                        even[evenIx] = arr[i];
                        evenIx++;
                    }
                }

                Console.WriteLine("Min val in array: {0}",minVal);
                Console.WriteLine("Max val in array: {0}", maxVal);
                Console.WriteLine("Sum of array: {0}", sumArr);
                Console.WriteLine("Avarage of array: {0}", (sumArr/arrSize));
                Console.ReadKey();
            }
        }
    }
}
