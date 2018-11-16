using System;
using System.Linq;
using System.Web;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Algorithms.ShortestPath;
using System.Collections.Generic;
using GOTO.Models;

namespace GOTO.Controllers
{
    public class ShortestPathCalculator
    {
        private AdjacencyGraph<string, CustomEdge> _graph;
        private Dictionary<Edge<string>, double> _costs;

        public void SetUpEdgesAndCosts(List<PricedRouteSegment> routeSegments, bool useTime)
        {
            _graph = new AdjacencyGraph<string, CustomEdge>();
            _costs = new Dictionary<Edge<string>, double>();
            List<PricedRouteSegment> combinedSegments = new List<PricedRouteSegment>();
            List<PricedRouteSegment> flippedSegments = new List<PricedRouteSegment>();

            foreach (var segment in routeSegments)
            {
                PricedRouteSegment tempSegment = new PricedRouteSegment(segment.ToCity.CityName,
                                                                        segment.FromCity.CityName,
                                                                        segment.Time,
                                                                        segment.Price,
                                                                        segment.Company);
                flippedSegments.Add(tempSegment);
            }

            combinedSegments.AddRange(routeSegments);
            combinedSegments.AddRange(flippedSegments);

            foreach (var route in combinedSegments)
            {
                AddEdgeWithCosts(route.FromCity.CityName,
                                 route.ToCity.CityName,
                                 route.Company,
                                 route.Price,
                                 route.Time,
                                 useTime);
            }
        }

        private void AddEdgeWithCosts(string source, string target, string company, double price, double time, bool useTime)
        {
            var edge = new CustomEdge(source, target, company, price, time);
            _graph.AddVerticesAndEdge(edge);
            if (useTime)
            {
                _costs.Add(edge, time);
            }
            else
            {
                _costs.Add(edge, price);
            }
            
        }

        public List<PricedRouteSegment> CalculateShortestPath(string from, string to)
        {
            var edgeCost = AlgorithmExtensions.GetIndexer(_costs);
            var tryGetPath = _graph.ShortestPathsDijkstra(edgeCost, from);
            List<PricedRouteSegment> result = new List<PricedRouteSegment>();
            IEnumerable<CustomEdge> path;
            if (tryGetPath(to, out path))
            {
                foreach (var segment in path)
                {
                    result.Add(new PricedRouteSegment(segment.Source.ToString(),
                                                      segment.Target.ToString(),
                                                      segment.Time,
                                                      segment.Price,
                                                      segment.Company));
                }

            }
            else
            {
                Console.WriteLine("No path found from {0} to {1}.");
            }

            return result;
        }
    }
}