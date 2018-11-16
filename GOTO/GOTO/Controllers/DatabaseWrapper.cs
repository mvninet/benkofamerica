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

        public void OpenConnection()
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

        public void CloseConnection()
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


            try
            {
                SqlDataReader Reader = null;
                var commandString =
                    "select OwnSegments.numcheckpoints, c1.name fromcity, c2.name tocity, OwnSegments.active " +
                    "from OwnSegments " +
                    "left join City c1 on (OwnSegments.fromcity = c1.cityid) " +
                    "left join City c2 on (OwnSegments.tocity = c2.cityid) " +
                    "where OwnSegments.active = 1";

                SqlCommand Command = new SqlCommand(commandString, Database);

                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    result.Add(new RouteSegment(Reader["fromcity"].ToString(),
                        Reader["tocity"].ToString(),
                        Convert.ToDouble(Reader["numcheckpoints"])));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            return result;
        }

        public double GetTypeCost(string typeName)
        {
            double typeCost = 1;
            try
            {
                SqlDataReader myReader = null;
                var commandString = "SELECT [typecost] " +
                                    "FROM[dbo].[types] " +
                                    "WHERE type = @Param";

                SqlParameter param = new SqlParameter("@Param", SqlDbType.VarChar,-1);
                param.Value = typeName;

                SqlCommand command = new SqlCommand(commandString, Database);
                command.Parameters.Add(param);

                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    typeCost = Convert.ToDouble(myReader["typecost"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return typeCost;
        }

        public List<PricedRouteSegment> GetOwnPricedSegments(double parcelTypePrice)
        {
            List<PricedRouteSegment> routeList = new List<PricedRouteSegment>();

            try
            {
                SqlDataReader reader = null;
                var commandString =
                    "select OwnSegments.numcheckpoints, c1.name fromcity, c2.name tocity, OwnSegments.active " +
                    "from OwnSegments " +
                    "left join City c1 on (OwnSegments.fromcity = c1.cityid) " +
                    "left join City c2 on (OwnSegments.tocity = c2.cityid) " +
                    "where OwnSegments.active = 1";

                SqlCommand command = new SqlCommand(commandString, Database);

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var fromCity = reader["fromcity"].ToString();
                    var toCity = reader["tocity"].ToString();
                    var checkpoints = Convert.ToDouble(reader["numcheckpoints"]);
                    var segmentTime = Convert.ToDouble(ConfigurationManager.AppSettings["SegmentTime"]);
                    var calculatedTime = checkpoints * segmentTime;
                    var calculatedPrice = checkpoints * Convert.ToDouble(ConfigurationManager.AppSettings["SegmentPrice"]) * parcelTypePrice;
                    routeList.Add(new PricedRouteSegment(fromCity,
                                                                  toCity,
                                                                  calculatedTime,
                                                                  calculatedPrice,
                                                                  "Telstar"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
            return routeList;
        }


    }
}