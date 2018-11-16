using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTO.Models
{
    public class PricedRouteSegment
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public double Time { get; set; }
        public double Price { get; set; }
        public string Company { get; set; }

        public PricedRouteSegment(string fromCity, string toCity, double time, double price, string company)
        {
            FromCity = fromCity;
            ToCity = toCity;
            Time = time;
            Price = price;
            Company = company;
        }

    }
}