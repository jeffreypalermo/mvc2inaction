using System;
using System.Collections.Generic;
using System.IO;

namespace AutocompleteExample.Models
{
    public class CityRepository : ICityRepository
    {
        private readonly string _csvFilename;
        private static List<string> _cities;

        public CityRepository(string csvFilename)
        {
            _csvFilename = csvFilename;

            lock (_csvFilename)
            {
                if (_cities == null)
                    LoadCities();
            }
        }

        private void LoadCities()
        {
            _cities = new List<string>();
            foreach (string line in File.ReadAllLines(_csvFilename))
                _cities.Add(line);
        }

        public string[] FindCities(string filter)
        {
            return _cities.FindAll(x => x.StartsWith(filter,
                StringComparison.CurrentCultureIgnoreCase)).ToArray();
        }
    }
}
