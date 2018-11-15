using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTO.Models
{
    public class Route
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public double Time { get; set; }
        public double Price { get; set; }
    }
}