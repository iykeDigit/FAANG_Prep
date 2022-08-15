using System;
using System.Collections.Generic;

namespace Prep
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[8][];
            jaggedArray[0] = new int[] { 0, 1 };
            jaggedArray[1] = new int[] { 0, 2 };
            jaggedArray[2] = new int[] { 3, 4 };
            jaggedArray[3] = new int[] { 3, 5 };
            jaggedArray[4] = new int[] { 4, 5 };
            jaggedArray[5] = new int[] { 6, 7 };
            jaggedArray[6] = new int[] { 7, 8};
            jaggedArray[7] = new int[] { 7, 9 };

            int[][] ShortestPathArray = new int[6][];
            ShortestPathArray[0] = new int[] { 0, 1 };
            ShortestPathArray[1] = new int[] { 0, 2 };
            ShortestPathArray[2] = new int[] { 1, 3 };
            ShortestPathArray[3] = new int[] { 1, 4 };
            ShortestPathArray[4] = new int[] { 2, 5 };
            ShortestPathArray[5] = new int[] { 4, 5 };

            var m = ShortestPath(6, ShortestPathArray,0, 4);
            Console.WriteLine();
        }


        public static int ShortestPath(int n, int[][] edges, int source, int destination)
        {
            var graph = BuildGraph(n, edges);
            var distance = new int[n];
            var visited = new bool[n];
            var queue = new Queue<int>();

            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                LinkedList<int> temp = graph[current];
                while(temp.Count > 0)
                {
                    if (visited[temp.First.Value] != true)
                    {
                        queue.Enqueue(temp.First.Value);
                        visited[temp.First.Value] = true;
                        distance[temp.First.Value] = distance[current] + 1;
                    }

                    if (temp.First.Value == destination)
                    {
                        return distance[temp.First.Value];
                    }
                    temp.RemoveFirst();
                }
            }

            return -1;
        }
        public static void BFS(int n, int[][] edges, int source)
        {
            var graph = BuildGraph(n, edges);
            Queue<int> queue = new();
            var visited = new bool[n];
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                visited[current] = true;
                Console.WriteLine(current);
                foreach (var item in graph[current])
                {
                    if (!visited[item])
                        queue.Enqueue(item);
                }
            }
        }

        private static LinkedList<int>[] BuildGraph(int n, int[][] edges)
        {
            var graph = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new LinkedList<int>();
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].AddLast(edge[1]);
                graph[edge[1]].AddLast(edge[0]);
            }

            return graph;
        }

        public static bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            if (source == destination) return true;
            var graph = BuildGraph(n, edges);
            var visited = new bool[n];
            var queue = new Queue<int>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                if (current == destination) return true;
                if (!visited[current])
                {
                    visited[current] = true;
                    foreach (var item in graph[current])
                    {
                        if (!visited[item])
                        {
                            queue.Enqueue(item);
                        }
                    }
                }
            }

            return false;
        }

        public static int CountConnectedComponents(int n, int[][] edges)
        {
            var graph = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new LinkedList<int>();
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].AddLast(edge[1]);
                graph[edge[1]].AddLast(edge[0]);
            }

            var count = 0;
            var visited = new bool[n];
            var queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    queue.Enqueue(i);
                    visited[i] = true;
                    while (queue.Count > 0)
                    {
                        int current = queue.Dequeue();
                        foreach (var item in graph[current])
                        {
                            if (!visited[item])
                            {
                                queue.Enqueue(item);
                                visited[item] = true;
                            }
                        }
                    }

                    count++;
                }
            }

            return count;
        }

        public static int LargestComponent(int n, int[][] edges)
        {
            var graph = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new LinkedList<int>();
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].AddLast(edge[1]);
                graph[edge[1]].AddLast(edge[0]);
            }

            var max = int.MinValue;
            var count = 0;
            var visited = new bool[n];
            var queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    queue.Enqueue(i);
                    count++;
                    visited[i] = true;
                    while (queue.Count > 0)
                    {
                        int current = queue.Dequeue();
                        foreach (var item in graph[current])
                        {
                            if (!visited[item])
                            {
                                queue.Enqueue(item);
                                visited[item] = true;
                                count++;
                            }
                        }
                    }
                    max = Math.Max(max, count);
                    count = 0;
                }
            }

            return max;
        }
    }
}
