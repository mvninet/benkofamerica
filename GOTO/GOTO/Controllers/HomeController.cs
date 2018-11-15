using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOTO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ConnectorController conController = new ConnectorController();
            //conController.GetRoutes("http://wa-oadk.azurewebsites.net/api/routes/", "?weight=1&type=1&height=1&width=1&length=1");
            conController.GetRoutes("http://nccesdkeit.azurewebsites.net/api/routes/", "?weight=1&typeOfGoods=1&month=1");
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