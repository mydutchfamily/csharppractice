using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_Loops_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawRectangle();

            DrawRightTriangle();

            DrawEquilateralTriangle();

            DrawRhombus();

            Console.ReadKey();
        }

        private static void DrawRhombus()
        {
            int length = 7;
            int height = 4;
            for (int i = 0; i < height; i++)
            {
                for (int ii = 0; ii < length; ii++)
                {
                    if ((ii >= (length / 2) - i) && (ii <= (length / 2) + i))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }

            for (int i = 1; i < height; i++)
            {
                for (int ii = 0; ii < length; ii++)
                {
                    if ((ii >= i) && (ii < (length - i)))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
        }

        private static void DrawEquilateralTriangle()
        {
            int length = 7;
            int height = 4;
            for (int i = 0; i < height; i++)
            {
                for (int ii = 0; ii < length; ii++)
                {
                    if ((ii >= (length / 2) - i) && (ii <= (length / 2) + i))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
        }

        private static void DrawRightTriangle()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int ii = 0; ii < i; ii++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }

        private static void DrawRectangle()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int ii = 0; ii < 6; ii++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }
    }
}
