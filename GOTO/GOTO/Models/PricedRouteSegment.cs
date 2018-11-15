using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTO.Models
{
    public class PricedRouteSegment
    {
        public City FromCity { get; set; }
        public City ToCity { get; set; }
        public double Time { get; set; }
        public double Price { get; set; }

        PricedRouteSegment(City fromCity, City toCity, double time, double price)
        {
            FromCity = fromCity;
            ToCity = ToCity;
            Time = time;
            Price = price;
        }

        PricedRouteSegment(string fromCityname, string toCityName, double time, double price)
        {
            FromCity = new City(fromCityname);
            ToCity = new City(toCityName);
            Time = time;
            Price = price;
        }
    }
}