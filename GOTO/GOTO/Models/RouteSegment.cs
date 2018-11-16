using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTO.Models
{
    public class RouteSegment
    {
        public City FromCity { get; set; }
        public City ToCity { get; set; }
        public double Time { get; set; }

        public RouteSegment(City fromCity, City toCity, double time)
        {
            FromCity = fromCity;
            ToCity = ToCity;
            Time = time;

        }

        public RouteSegment(string fromCityname, string toCityName, double time)
        {
            FromCity = new City(fromCityname);
            ToCity = new City(toCityName);
            Time = time;

        }
    }
}