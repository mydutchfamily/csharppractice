using System.IO;
using System.Collections.Generic;

namespace dictsnippets
{
    class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }

        public Dictionary<string, Country> ReadAllCountries()
        {
            Dictionary<string, Country> countries = new Dictionary<string, Country>();

            using (var sr = new StreamReader(_csvFilePath))
            {
                // read header line
                sr.ReadLine();
                string csvLine;

                while ((csvLine = sr.ReadLine()) != null)
                {              
                    Country country =  ReadCountryFromCsvLine(csvLine);
                    countries.Add(country.Code, country);
                }

            }

            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            List<string> parts = new List<string>();
            parts.AddRange(csvLine.Split('"'));

            if(parts.Count == 3){                
                parts.RemoveAt(0);                
                parts.AddRange(parts[1].Split(','));
                parts.RemoveRange(1,2);
            }else{
                parts.AddRange(csvLine.Split(','));
                parts.RemoveAt(0);
            }

            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int.TryParse(parts[3], out int population);

            return new Country(name, code, region, population);
        }
    }

}