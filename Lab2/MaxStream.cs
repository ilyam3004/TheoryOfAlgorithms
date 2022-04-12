using System;

namespace Lab2
{
    public class MaxStream
    {
        private static Graph graph = new();
        static void Main(string[] args)
        {
            FordFulkerson();
        }
        public static void FordFulkerson()
        {
            bool saturated = false;
            int source = graph.vertexes[6];
            int stock = graph.vertexes[10];
            int currVetrex = source;
            List<Edge> pathEdges = new();
            while (!saturated)
            {
                int localMaxThroughput = 0;
                int potentialVertex = 0;
                Edge potentialEdge = null;
                if (graph.isAdjacent(currVetrex, stock))
                {
                    if (graph.edgeMatrix[currVetrex - 1, stock - 1] != null)
                    {
                        localMaxThroughput = graph.edgeMatrix[currVetrex - 1, stock - 1].weight;
                        pathEdges.Add(graph.edgeMatrix[currVetrex - 1, stock - 1]);
                        currVetrex = stock;
                        saturated = true;
                    }
                }
                else
                {
                    List<int> pathAbleVertexes = graph.PathAbleVertexes(currVetrex);
                    for (int i = 0; i < pathAbleVertexes.Count; i++)
                    {
                        if (graph.edgeMatrix[currVetrex - 1, pathAbleVertexes[i] - 1] != null)
                        {
                            if (graph.edgeMatrix[currVetrex - 1, pathAbleVertexes[i] - 1].weight > localMaxThroughput)
                            {
                                localMaxThroughput = graph.edgeMatrix[currVetrex - 1, pathAbleVertexes[i] - 1].weight;
                                potentialVertex = pathAbleVertexes[i];
                                potentialEdge = graph.edgeMatrix[currVetrex - 1, pathAbleVertexes[i] - 1];
                            }
                        }
                    }
                    currVetrex = potentialVertex;
                    pathEdges.Add(potentialEdge);
                }
            }
            graph.SetFlow(pathEdges, graph.GetMinThroughput(pathEdges));
            foreach (var item in pathEdges)
                System.Console.WriteLine(item.flow);
        }
    }
}