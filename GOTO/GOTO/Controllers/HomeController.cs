using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOTO.Controllers;


namespace GOTO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
            var test = db.GetOwnPricedSegments(testpricemultiplier);

            ShortestPathCalculator path = new ShortestPathCalculator();
            path.SetUpEdgesAndCosts(test, true);
            path.CalculateShortestPath("Kap Guardafui", "Sierra Leone");
            return View();
        }
    }
}