﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GOTO.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Configuration;

namespace GOTO.Controllers
{
    public class TelstarController : ApiController
    {
        // GET: api/Telstar
        public string Get()
        {
          return "Sorry, Wrong Input Parameters. try with Weight and ParcelType";
        }

        // GET: api/Telstar/5
        public String Get(int weight, String ParcelType)
        {
            DatabaseWrapper db = new DatabaseWrapper(ConfigurationManager.AppSettings["DatabaseUserName"],
                                                     ConfigurationManager.AppSettings["DatabasePassword"],
                                                     ConfigurationManager.AppSettings["DatabaseConnectionURL"],
                                                     ConfigurationManager.AppSettings["DatabaseTrustedConnection"].ToString(),
                                                     ConfigurationManager.AppSettings["DatabaseName"].ToString(),
                                                     Convert.ToInt32(ConfigurationManager.AppSettings["DatabaseConnectionTimeOut"]));

            return JsonConvert.SerializeObject(db.GetOwnPricedSegments());
        }
    }
}
