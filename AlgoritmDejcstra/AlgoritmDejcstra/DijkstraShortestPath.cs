using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmDejcstra
{
    internal class DijkstraShortestPath
    {
        public static int[] Dijkstra(int startNode, Dictionary<int, Dictionary<int, int>> graph)
        {
            int n = graph.Count;
            int[] distances = new int[n];
            bool[] visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                distances[i] = int.MaxValue;
            }

            distances[startNode] = 0;

            for (int i = 0; i < n - 1; i++)
            {
                int u = GetClosestUnvisitedNode(distances, visited);

                if (u == -1)
                {
                    break;
                }

                visited[u] = true;

                foreach (var neighbor in graph[u])
                {
                    int v = neighbor.Key;
                    int weight = neighbor.Value;

                    if (!visited[v] && distances[u] != int.MaxValue && distances[u] + weight < distances[v])
                    {
                        distances[v] = distances[u] + weight;
                    }
                }
            }

            return distances;
        }

        private static int GetClosestUnvisitedNode(int[] distances, bool[] visited)
        {
            int minDistance = int.MaxValue;
            int minDistanceNode = -1;

            for (int i = 0; i < distances.Length; i++)
            {
                if (!visited[i] && distances[i] < minDistance)
                {
                    minDistance = distances[i];
                    minDistanceNode = i;
                }
            }

            return minDistanceNode;
        }
    }
}
