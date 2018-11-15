using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTO.Models
{
    public class Company
    {
        public string CompanyName { get; set; }

        public Company(string companyName)
        {
            this.CompanyName = companyName;
        }
    }
}