using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEquals
{
    class StringComparisons
    {
        public static void DisplayAllComparisons(string str1, string str2) {
            DisplayComparison(str1, str2, StringComparison.Ordinal);
            DisplayComparison(str1, str2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine();
            DisplayComparison(str1, str2, StringComparison.InvariantCulture);
            DisplayComparison(str1, str2, StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine();
            DisplayComparison(str1, str2, StringComparison.CurrentCulture);
            DisplayComparison(str1, str2, StringComparison.CurrentCultureIgnoreCase);
        }
        public static void DisplayComparison(string str1, string str2, StringComparison comparison) {
            int result = string.Compare(str1, str2, comparison);
            Console.WriteLine("{0} {1} {2}   ({3}, {4})", str1, GetCompareSymbol(result), str2, result, comparison);
        }

        private static string GetCompareSymbol(int result)
        {
            if (result == 0)
                return "==";
            else if (result < 0)
                return "<";
            else
                return ">";
        }
    }
}
