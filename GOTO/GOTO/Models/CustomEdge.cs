using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickGraph;
namespace GOTO.Models
{
    public class CustomEdge : Edge<string>
    {
        public string Company { get; set; }
        public double Price { get; set; }
        public double Time { get; set; }

        public CustomEdge(string source, string target, string company, double price, double time) : base(source, target)
        {
            Company = company;
            Price = Price;
            Time = time;

        }
    }
}