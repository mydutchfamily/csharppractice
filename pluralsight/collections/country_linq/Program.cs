using System;
using System.Collections.Generic;
using  System.Linq;

namespace country_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);

           List<Country> countries = reader.ReadAllCountries();

           var filteredCountries = from country in countries
           where !country.Name.Contains(",")
           select country;

            foreach (Country country in countries.Take(20).Where(x=> !x.Name.Contains(",")).OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }

            System.Console.WriteLine($"{countries.Count} countries");
        }
    }
}
