using System;

namespace Lab2
{
    public class MaxStream
    {
        private Graph graph = new();
        //private int[,] AdjMatrix; 
        //private List<int> maxFlows;
        public int FordFulkerson()
        {
            // maxFlows = new();
            // AdjMatrix = graph.AdjMatrix();
            bool saturated = false;
            int source = graph.vertexes[6];
            int stock = graph.vertexes[10];
            int currVetrex = source;
            while (!saturated)
            {
                //int maxFlow = 0;
                List<int> pathAbleVertexes = graph.PathAbleVertexes(currVetrex);
                foreach (var item in pathAbleVertexes)
                {
                }
            }
            return 0;
        }
    }
}