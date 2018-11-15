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
        public double price { get; set; }
    }
}