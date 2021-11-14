using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouGoGetData.Classes
{
   public  class Country
    {
        public Country()
        {

        }

        public string name { get; set; }


        public static List<Country> getCountryList()
        {
            Country countryEs = new Country()
            {
                name = "西班牙(Spain)"
            };
            Country countryIt = new Country()
            {
                name = "意大利(Italy)"
            };

            List<Country> countries = new List<Country>();
            countries.Add(countryIt);
            countries.Add(countryEs);

            return countries;
        }

    }
}
