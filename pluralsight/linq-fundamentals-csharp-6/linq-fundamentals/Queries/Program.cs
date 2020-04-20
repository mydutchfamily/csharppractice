using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie> {
                new Movie{ Title = "The Dark Knight", Rating = 8.9f, Year = 2008},
                new Movie{ Title = "The King's Speech", Rating = 8.0f, Year = 2010},
                new Movie{ Title = "Casablanca", Rating = 8.5f, Year = 1942},
                new Movie{ Title = "Star war V", Rating = 8.7f, Year = 1980}
            };

            var query = movies.Where(m => m.Year > 2000);

            foreach (var item in query)
            {
                Console.WriteLine(item.Title);
            }
            Console.WriteLine("***********************************");
            query = movies.Filter(m => m.Year > 2000);

            foreach (var item in query)
            {
                Console.WriteLine(item.Title);
            }
            Console.WriteLine("***********************************");
            query = movies.Filter2(m => m.Year > 2000);

            foreach (var item in query)
            {
                Console.WriteLine(item.Title);
            }

            Console.WriteLine("***********************************");
            query = movies.Filter2(m => m.Year > 2000).ToList();// will run query once to get results

            Console.WriteLine(query.Count());
            var enumerator = query.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }
        }
    }
}
