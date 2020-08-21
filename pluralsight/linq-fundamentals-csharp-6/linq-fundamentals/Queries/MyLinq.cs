using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    public static class MyLinq
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate) {// will execute whole code anyway
            var result = new List<T>();

            foreach (var item in source)
            {
                if (predicate(item)) {
                    result.Add(item);
                }
            }

            return result;
        }

        public static IEnumerable<T> Filter2<T>(this IEnumerable<T> source, Func<T, bool> predicate)// will execute the code only when looping
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<double> Random()
        {// will return numbers infinitely
            var random = new Random();
            while (true) {
                yield return random.NextDouble();
            }
        }
    }
}
