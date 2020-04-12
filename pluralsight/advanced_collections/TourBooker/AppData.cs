using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBooker.Logic
{
    public class AppData
    {
        public List<Country> AllCountries { get; private set; }
        public Dictionary<string, Country> AllCountriesByKey { get; private set;}
        public SortedDictionary<string, Country> AllCountriesByKeySorted { get; private set; }
        public void Initialize(string csvFilePath) {
            CsvReader reader = new CsvReader(csvFilePath);
            this.AllCountries = reader.ReadAllCountries().OrderBy(x=>x.Name).ToList();

            this.AllCountriesByKey = AllCountries.ToDictionary(x => x.Code, StringComparer.OrdinalIgnoreCase); // add statndart comparator to ignore case 

            this.AllCountriesByKeySorted = new SortedDictionary<string, Country>(AllCountriesByKey);

        }
    }
}
