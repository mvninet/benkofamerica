using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOTO.Models;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;
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

        public List<PricedRouteSegment> GetOceanicRoutes(Double weight, string type, double height, double width, double length)
        {
            List<PricedRouteSegment> result = new List<PricedRouteSegment>();
            var response = GetRoutes("http://wa-oadk.azurewebsites.net/api/routes/", "?weight=" + weight + "&type=" + type + "&height=" + height + "&width=" + width + "&length=" + length, "Oceanic Airlines");

            foreach(var segment in response)
            {
                result.Add(new PricedRouteSegment(segment.FromCity, segment.ToCity, segment.Time, segment.Price, segment.Company));
            }
            return result;
        }

        public List<PricedRouteSegment> GetEastIndiaRoutes(Double weight, string type, string date)
        {

            List<PricedRouteSegment> result = new List<PricedRouteSegment>();
            var response = GetRoutes("http://nccesdkeit.azurewebsites.net/api/routes/", "?weight=" + weight + "&typeOfGoods=" + type + "&date=" + date, "East Indian Trading Co.");

            foreach (var segment in response)
            {
                result.Add(new PricedRouteSegment(segment.FromCity, segment.ToCity, segment.Time, segment.Price, segment.Company));
            }
            return result;
        }

        public string getCities()
        {
            List<String> cities = new List<string>();
            var eastindia = GetEastIndiaRoutes(5, "Live animals", "10-10-2010");
            foreach (var path in eastindia)
            {
                cities.Add(path.FromCity);
                cities.Add(path.ToCity);
            }
            var oceanic = GetOceanicRoutes(5, "Live animals", 10, 10, 10);
            foreach (var path in oceanic)
            {
                cities.Add(path.FromCity);
                cities.Add(path.ToCity);
            }

            DatabaseWrapper db = new DatabaseWrapper(ConfigurationManager.AppSettings["DatabaseUserName"],
                                         ConfigurationManager.AppSettings["DatabasePassword"],
                                         ConfigurationManager.AppSettings["DatabaseConnectionURL"],
                                         ConfigurationManager.AppSettings["DatabaseTrustedConnection"].ToString(),
                                         ConfigurationManager.AppSettings["DatabaseName"].ToString(),
                                         Convert.ToInt32(ConfigurationManager.AppSettings["DatabaseConnectionTimeOut"]));

            db.OpenConnection();
            var telstar = db.GetOwnPricedSegments(10);
            db.CloseConnection();
            foreach (var path in telstar)
            {
                cities.Add(path.FromCity);
                cities.Add(path.ToCity);
            }
            var noDups = cities.Distinct().ToList();
            //return noDups;
            return JsonConvert.SerializeObject(noDups);



        }


    }
    }
