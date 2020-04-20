using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    public static class MyLinq
    {
        public static int Count<T>(this IEnumerable<T> sequence) { // because of "this" method becomes an extention
            int count = 0;
            foreach (var item in sequence)
            {
                count += 1;
            }

            return count;
        }
    }
}
