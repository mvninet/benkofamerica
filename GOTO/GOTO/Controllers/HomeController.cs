using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOTO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // ShortestPathCalculator path = new ShortestPathCalculator();
            // path.SetUpEdgesAndCosts();
            // path.PrintShortestPath("A", "B");
            ConnectorController connector = new ConnectorController();
            connector.GetEastIndiaRoutes(10.0, "Weapons", "10-10-2018");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}