using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_ConditionsRange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("There are several periods [0 - 14] [15 - 35] [36 - 50][50 - 100]");
            Console.WriteLine("enter a number and program will show in what period it is");
            int num = 0;
            int.TryParse(Console.ReadLine(), out num);
            int periodnum = 0;

            if (num >= 0 && num <= 14)
            {
                periodnum = 1;
            }
            else if (num >= 15 && num <= 35)
            {
                periodnum = 2;
            }
            else if (num >= 36 && num <= 50)
            {
                periodnum = 3;
            }
            else if (num > 50 && num <= 100)
            {
                periodnum = 4;
            }
            else
            {
                periodnum = -1;
            }

            Console.WriteLine(periodnum > 0 ? string.Format("Number {0} in {1} period", num, periodnum) : string.Format("Number {0}, not in any period", num));
            Console.ReadKey();
        }
    }
}
