using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GOTO.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace GOTO.Controllers
{
    public class TelstarController : ApiController
    {
        // GET: api/Telstar
        public IEnumerable<string> Get()
        {
            return new string[] { "Sorry, Wrong Input Parameters. try with Weight and ParcelType" };
        }

        // GET: api/Telstar/5
        public RoutesModel Get(int weight, String ParcelType)
        {
            Route route1 = new Route
            {
                FromCity = "startCity1",
                ToCity = "endCity1",
                Time = 7.5,
                Price = 230.5
            };
            Route route2 = new Route
            {
                FromCity = "startCity2",
                ToCity = "endCity2",
                Time = 7.5,
                Price = 230.5
            };

            RoutesModel Routes = new RoutesModel();
            Routes.Routes.Add(route1);
            Routes.Routes.Add(route2);

            return Routes;
        }
    }
}
