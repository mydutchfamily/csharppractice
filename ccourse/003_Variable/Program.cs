using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 3, num2 = 5;
            Console.WriteLine("all math operations at {0} and {1}", num1, num2);
            Console.WriteLine($"sum :{num1 + num2}");
            Console.WriteLine($"multiplication :{num1 * num2}");
            Console.WriteLine($"divition :{num1 / num2}");
            Console.WriteLine($"reminder :{num1 % num2}");
            Console.WriteLine($"sqrt :{Math.Sqrt(num1)}");
            Console.WriteLine($"Pow :{Math.Pow(num1, num2)}");
            Console.WriteLine($"increase :{++num1}");
            Console.WriteLine($"decrease :{--num1}");

            Console.WriteLine("Press ANY key to continue");
            Console.ReadKey();

            int x = 10, y = 12, z = 3;
            Console.WriteLine("math operations at {0}, {1} and {2}", x, y, z);
            Console.WriteLine($"x += y - x++ * z :{x += y - x++ * z}");
            Console.WriteLine($"z = --x - y * 5 :{z = --x - y * 5}");
            Console.WriteLine($"y /= x + 5 % z :{y /= x + 5 % z}");
            Console.WriteLine($"z = x++ + y * 5 :{z = x++ + y * 5}");
            Console.WriteLine($"x = y - x++ * z :{x = y - x++ * z}");

            Console.WriteLine("Press ANY key to continue");
            Console.ReadKey();

            double avg = x + y + z;
            Console.WriteLine($"average :{avg / 3}");

            Console.WriteLine("Press ANY key to continue");
            Console.ReadKey();

            const double pi = Math.PI;
            double r = 3;
            Console.WriteLine($"S of circle :{pi*Math.Pow(r,2)}");

            Console.WriteLine("Press ANY key to continue");
            Console.ReadKey();

            Console.WriteLine("Going to calculate V and S of cylinder");
            Console.WriteLine("Enter a radius of cylinder:");
            double cr = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter a hight of cylinder:");
            double ch = Convert.ToDouble(Console.ReadLine());

            double s = 2*pi*cr*(cr+ch);
            double v = pi*cr*cr*ch;
            Console.WriteLine("V and S of cylinder are {0} and {1}", v, s);

            Console.WriteLine("Press ANY key to continue");
            Console.ReadKey();

            //int uberflu? = 0;
            int _Identifier = 0;
            int \u006fIdentifier = 0;
            //int &myVar = 0;
            int myVariab1le = 0;

        }
    }
}
