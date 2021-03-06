﻿using System;
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
        public Dictionary<CountryCode, Country> AllCountriesCCByKey { get; private set; }
        public SortedDictionary<string, Country> AllCountriesByKeySorted { get; private set; }
        public SortedList<string, Country> AllCountriesByKeySortedList { get; private set; }

        public LinkedList<Country> ItineraryBuilder { get; } = new LinkedList<Country>();
        public SortedDictionary<string, Tour> AllTurs { get; private set; } = new SortedDictionary<string, Tour>();
        public void Initialize(string csvFilePath) {
            CsvReader reader = new CsvReader(csvFilePath);
            this.AllCountries = reader.ReadAllCountries().OrderBy(x=>x.Name).ToList();

            this.AllCountriesByKey = AllCountries.ToDictionary(x => x.Code, StringComparer.OrdinalIgnoreCase); // add statndart comparator to ignore case 

            this.AllCountriesCCByKey = AllCountries.ToDictionary(x => x.CountryCode);

            this.AllCountriesByKeySorted = new SortedDictionary<string, Country>(AllCountriesByKey);

            this.AllCountriesByKeySortedList = new SortedList<string, Country>(AllCountriesByKey);



        }
    }
}
