using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> square = x => x*x; // last int is type for return
            Console.WriteLine(square(3));

            Func<int, int, int> add =  (x,y) => x + y;
            Func<int, int, int> add2 = (x, y) =>
            {
                int z = x + y;
                return z;
            };

            Console.WriteLine(square(add(3, add2(2,2))));

            Action<int> write = x => Console.WriteLine(x);
            write(square(add(3, add2(2, 2))));

            Console.WriteLine("*****************");

            IEnumerable<Employee> developers = new Employee[]
                {
                    new Employee { Id = 1, Name = "Scott"},
                    new Employee { Id = 2, Name = "Chris"}
                };

            IEnumerable<Employee> sales = new List<Employee>() {
                new Employee { Id = 3, Name = "Alex"}
            };

            Console.WriteLine(sales.Count());
            IEnumerator<Employee> enumerator = developers.GetEnumerator();

            while (enumerator.MoveNext()) {
                Console.WriteLine(enumerator.Current.Name);
            }

            Console.WriteLine("*****************");
            foreach (var item in developers.Where(NameStartsWithS))
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("*****************");
            foreach (var item in developers.Where(delegate (Employee arg)
        {
                return arg.Name.StartsWith("S");
            }))
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("*****************");
            foreach (var item in developers.Where(arg=> arg.Name.StartsWith("S")))
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("*****************");
            foreach (var item in developers.Where(arg => arg.Name.Length == 5)
                                            .OrderBy(e => e.Name))
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("*****************");
            var query = developers.Where(arg => arg.Name.Length == 5)
                                            .OrderBy(e => e.Name);
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("*****************");
            var query2 = from dev in developers
                        where dev.Name.Length == 5
                        orderby dev.Name
                        select dev;

            foreach (var item in query2)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static bool NameStartsWithS(Employee arg)
        {
            return arg.Name.StartsWith("S");
        }
    }
}
