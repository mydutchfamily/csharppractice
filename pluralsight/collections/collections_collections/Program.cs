using System;
using System.Collections.Generic;

namespace collections_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);

           Dictionary<string,List<Country>> countries = reader.ReadAllCountries();
           List<string> regions = new List<string>();
           regions.AddRange(countries.Keys);
           int ix = 0;
           foreach(string region in regions){               
               System.Console.WriteLine($"enter number {ix++} for {region} with {countries[region].Count} countries");
           }

           System.Console.WriteLine("Which one region you want to list?");
           int.TryParse(Console.ReadLine(), out int regionNum);

            foreach (Country country in countries[regions[regionNum]])
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }

            System.Console.WriteLine($"{countries[regions[regionNum]].Count} countries");
        }
    }
}
