using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOTO.Controllers;
using GOTO.Models;
using Newtonsoft.Json;

namespace GOTO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
                return View();
            }
        public String getRoutes(string weight, string type, string height, string width, string depth, string from, string to)
        {
            List<List<PricedRouteSegment>> result = new List<List<PricedRouteSegment>>();

            DatabaseWrapper db = new DatabaseWrapper(ConfigurationManager.AppSettings["DatabaseUserName"],
                                                     ConfigurationManager.AppSettings["DatabasePassword"],
                                                     ConfigurationManager.AppSettings["DatabaseConnectionURL"],
                                                     ConfigurationManager.AppSettings["DatabaseTrustedConnection"].ToString(),
                                                     ConfigurationManager.AppSettings["DatabaseName"].ToString(),
                                                     Convert.ToInt32(ConfigurationManager.AppSettings["DatabaseConnectionTimeOut"]));

            db.OpenConnection();
            var testpricemultiplier = db.GetTypeCost("Recorded");
            db.CloseConnection();
            db.OpenConnection();
            var telstar = db.GetOwnPricedSegments(testpricemultiplier);
            db.CloseConnection();
            ConnectorController connector = new ConnectorController();

            var oceanic = connector.GetOceanicRoutes(Convert.ToDouble(weight), type, Convert.ToDouble(height), Convert.ToDouble(width), Convert.ToDouble(depth));
            var eastindia = connector.GetEastIndiaRoutes(Convert.ToDouble(weight), type, "10-10-2018");
            var map = telstar.Concat(oceanic).Concat(eastindia).ToList();

            ShortestPathCalculator fastPath = new ShortestPathCalculator();
            fastPath.SetUpEdgesAndCosts(map, true);
            var fastestPath = fastPath.CalculateShortestPath(from, to);

            ShortestPathCalculator cheapPath = new ShortestPathCalculator();
            cheapPath.SetUpEdgesAndCosts(map, false);
            var cheapestPath = cheapPath.CalculateShortestPath(from, to);

            result.Add(fastestPath);
            result.Add(cheapestPath);
            return JsonConvert.SerializeObject(result);
        }
        }
}