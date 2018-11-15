using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using GOTO.Models;
using System.Configuration;

namespace GOTO.Controllers
{
    public class DatabaseWrapper
    {
        public SqlConnection Database { get; set; }

        public DatabaseWrapper(string username, string password, string serverUrl, string trustedConnection, string databaseName, int connectionTimeOut)
        {
            Database = new SqlConnection(String.Format("user id={0};" +
                                                       "password={1};" +
                                                       "server={2};" +
                                                       "Trusted_Connection={3};" +
                                                       "database={4}; " +
                                                       "connection timeout={5}",
                                                       username,
                                                       password,
                                                       serverUrl,
                                                       trustedConnection,
                                                       databaseName,
                                                       connectionTimeOut));
        }

        private void OpenConnection()
        {
            try
            {
                Database.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void CloseConnection()
        {
            try
            {
                Database.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public List<RouteSegment> GetOwnSegments()
        {
            List<RouteSegment> result = new List<RouteSegment>();
            OpenConnection();

            try
            {
                SqlDataReader myReader = null;
                var commandString =
                    "select OwnSegments.numcheckpoints, c1.name fromcity, c2.name tocity, OwnSegments.active " +
                    "from OwnSegments " +
                    "left join City c1 on (OwnSegments.fromcity = c1.cityid) " +
                    "left join City c2 on (OwnSegments.tocity = c2.cityid) " +
                    "where OwnSegments.active = 1";

                SqlCommand myCommand = new SqlCommand(commandString, Database);

                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    result.Add(new RouteSegment(myReader["fromcity"].ToString(),
                        myReader["tocity"].ToString(),
                        Convert.ToDouble(myReader["numcheckpoints"])));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            CloseConnection();

            return result;
        }

        public RoutesModel GetOwnPricedSegments()
        {
            RoutesModel routesModel = new RoutesModel();
            OpenConnection();

            try
            {
                SqlDataReader myReader = null;
                var commandString =
                    "select OwnSegments.numcheckpoints, c1.name fromcity, c2.name tocity, OwnSegments.active " +
                    "from OwnSegments " +
                    "left join City c1 on (OwnSegments.fromcity = c1.cityid) " +
                    "left join City c2 on (OwnSegments.tocity = c2.cityid) " +
                    "where OwnSegments.active = 1";

                SqlCommand myCommand = new SqlCommand(commandString, Database);

                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    routesModel.Routes.Add(new PricedRouteSegment(myReader["fromcity"].ToString(),
                        myReader["tocity"].ToString(),
                        Convert.ToDouble(myReader["numcheckpoints"]) * Convert.ToDouble(ConfigurationManager.AppSettings["SegmentTime"]),
                        0));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            CloseConnection();
            
            return routesModel;
        }


    }
}