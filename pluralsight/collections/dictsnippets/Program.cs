using System;
using System.Collections.Generic;

namespace dictsnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            Country norway = new Country("Norway", "NOR", "Europe", 5_282_223);
            Country finland = new Country("Finland", "FIN", "Europe", 5_511_303);

            Dictionary<string, Country> countries = new Dictionary<string, Country>{
                {norway.Code, norway}
            };

            countries.Add(finland.Code, finland);

            Country selectedCountry = countries["NOR"];
            System.Console.WriteLine(selectedCountry.Name);

            bool exists = countries.TryGetValue("MUS", out Country countryIn);

            if (exists)
                System.Console.WriteLine(countryIn.Name);
            else
            {
                System.Console.WriteLine("No such country");
            }

            foreach (KeyValuePair<string, Country> country in countries)
            {
                System.Console.WriteLine(country.Value.Name);
            }

            // read from file
            
            string filePath = "Pop by Largest Final.csv";
            CsvReader csvReader = new CsvReader(filePath);
            countries = csvReader.ReadAllCountries();

            System.Console.WriteLine("Which country code do you want to loo up?");
            string userInput = Console.ReadLine();

            bool gotCountry = countries.TryGetValue(userInput, out Country countryGot);

            if (!gotCountry)
                System.Console.WriteLine("No such country");
            else
            {
                System.Console.WriteLine($"{countryGot.Name} has population {PopulationFormatter.FormatPopulation(countryGot.Population)}");
            }
        }
    }
}
