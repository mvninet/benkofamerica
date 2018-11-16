﻿using System;
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
        public string Company { get; set; }

        public PricedRouteSegment(City fromCity, City toCity, double time, double price, string company)
        {
            FromCity = fromCity;
            ToCity = ToCity;
            Time = time;
            Price = price;
            Company = company;
        }

        public PricedRouteSegment(string fromCityname, string toCityName, double time, double price, string company)
        {
            FromCity = new City(fromCityname);
            ToCity = new City(toCityName);
            Time = time;
            Price = price;
            Company = company;
        }
    }
}