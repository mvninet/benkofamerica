﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOTO.Models;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace GOTO.Controllers
{
    public class ConnectorController : Controller
    {

        public class DataObject
        {
            public string Name { get; set; }
        }

        public List<Route> GetRoutes(String url, String urlParam, string company)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParam).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

            var readAsStringAsync = response.Content.ReadAsStringAsync();

            var RootObjects = JsonConvert.DeserializeObject<List<Route>>(readAsStringAsync.Result);
            foreach(var path in RootObjects)
            {
                path.Company = company;
            }
            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            return RootObjects;
        }

        public List<Route> GetOceanicRoutes(Double weight, string type, double height, double width, double length)
        {
            var result = GetRoutes("http://wa-oadk.azurewebsites.net/api/routes/", "?weight=" + weight + "&type=" + type + "&height=" + height + "&width=" + width + "&length=" + length, "Oceanic Airlines");
            return result;
        }

        public List<Route> GetEastIndiaRoutes(Double weight, string type, string date)
        {
            var result = GetRoutes("http://nccesdkeit.azurewebsites.net/api/routes/", "?weight=" + weight + "&typeOfGoods=" + type + "&date=" + date, "East Indian Trading Co.");
            return result;
        }


    }
    }
