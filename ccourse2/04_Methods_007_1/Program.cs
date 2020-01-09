using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Methods_007_1
{
    class Program
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Sub(int x, int y)
        {
            return x - y;
        }

        public static int Mul(int x, int y)
        {
            return x * y;
        }

        public static int Div(int x, int y)
        {
            return y == 0 ? 0 : x / y;
        }
        static void Main(string[] args)
        {
            int optype;

            if (getOptType(out optype))
            {
                int[] inputVar = getParams();
                int result = DoCalc(optype, inputVar);

                Console.WriteLine("Result: {0}", result);
                Console.ReadKey();
            }
        }

        private static int DoCalc(int optype, int[] inputVar)
        {
            int result;
            switch (optype)
            {
                case 1:
                    {
                        result = Add(inputVar[0], inputVar[1]);
                        break;
                    }
                case 2:
                    {
                        result = Sub(inputVar[0], inputVar[1]);
                        break;
                    }
                case 3:
                    {
                        result = Mul(inputVar[0], inputVar[1]);
                        break;
                    }
                case 4:
                    {
                        result = Div(inputVar[0], inputVar[1]);
                        break;
                    }
                default:
                    {
                        result = 0;
                        break;
                    }
            }

            return result;
        }

        private static int[] getParams()
        {
            string[] inputStr = new string[] { "first", "second" };
            int[] inputVar = new int[] { 0, 0};

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Enter {0} parameter:", inputStr[i]);
                Int32.TryParse(Console.ReadLine(), out inputVar[i]);
            }

            return inputVar;
        }

        private static Boolean getOptType(out int optype)
        {
            Console.WriteLine("Enter number for operation type: Add(1), Sub(2), Mul(3), Div(4)");
            return Int32.TryParse(Console.ReadLine(), out optype);
        }
    }
}
