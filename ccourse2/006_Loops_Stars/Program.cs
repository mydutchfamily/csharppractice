using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_Loops_Stars
{
    class Program
    {
        static void Main(string[] args)
        {

            Draw(7, 3);

            Console.ReadKey();
        }

        private static void Draw(int col, int row)
        {
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
        }
    }
}
