using System;
using System.Linq;
using System.Web;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Algorithms.ShortestPath;
using System.Collections.Generic;

namespace GOTO.Controllers
{
    public class ShortestPathCalculator
    {
        private UndirectedGraph<string, Edge<string>> _graph;
        private Dictionary<Edge<string>, double> _costs;

        public void SetUpEdgesAndCosts()
        {
            _graph = new UndirectedGraph<string, Edge<string>>();
            _costs = new Dictionary<Edge<string>, double>();

            
            
            AddEdgeWithCosts("A", "B", 5.0);

        }

        private void AddEdgeWithCosts(string source, string target, double cost)
        {
            var edge = new Edge<string>(source, target);
            _graph.AddVerticesAndEdge(edge);
            _costs.Add(edge, cost);
        }

        public void PrintShortestPath(string @from, string to)
        {
            var edgeCost = AlgorithmExtensions.GetIndexer(_costs);
            var tryGetPath = _graph.ShortestPathsDijkstra(edgeCost, @from);

            IEnumerable<Edge<string>> path;
            if (tryGetPath(to, out path))
            {
                var fr = @from;
                var xto = to;
                var p = path;

            }
            else
            {
                Console.WriteLine("No path found from {0} to {1}.");
            }
        }
    }
}