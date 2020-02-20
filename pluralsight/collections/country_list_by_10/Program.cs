using System;
using System.Collections.Generic;

namespace country_list_by_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);

           List<Country> countries = reader.ReadAllCountries();

            System.Console.WriteLine("How many countries to show?");
            string count = Console.ReadLine();
            int.TryParse(count, out int countCountries);

            for (int ix = 0; ix < countries.Count; ix++)
            {
                 if((0 == ix % countCountries) & (ix > 0)){
                    System.Console.WriteLine("press enter to continue or else to quite");
                    if (!string.IsNullOrEmpty(Console.ReadLine())){
                        break;
                    }
                }
                
                Country country = countries[ix];
                Console.WriteLine($"{ix+1} {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }

            System.Console.WriteLine($"{countries.Count} countries");
        }
    }
}
