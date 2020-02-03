using System;

namespace country_csv
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "PopByLargestFinal.csv";

            CsvReader reader = new CsvReader(filePath);

            Country[] countries = reader.ReadFirstNCountries(4);

            foreach (Country country in countries)
            {
                System.Console.WriteLine($"{country.Population}: {country.Name}");
            }
        }
    }
}
