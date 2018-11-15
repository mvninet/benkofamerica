using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTO.Models
{
    public class City
    {
        public string CityName { get; set; }

        public City(string cityName)
        {
            CityName = cityName;
        }
    }
}