using System;
using System.Collections.Generic;


namespace Lab2
{
    public class Graph
    {
        public int[,] flowMatrix;
        public int[,] incMatrix;
        private Edge[] edges;
        public int[] vertexes;
        public Graph()
        {
            edges = SetEdges();
            vertexes = SetVertexes();
            incMatrix = IncMatrix();
            flowMatrix = new int[vertexes.Length, edges.Length];
        }
        public int[,] IncMatrix()
        {
            int[,] matrix = new int[vertexes.Length, edges.Length];
            for (int i = 0; i < vertexes.Length; i++)
            {
                for (int j = 0; j < edges.Length; j++)
                {
                    if (vertexes[i] == edges[j].startVertex || vertexes[i] == edges[j].endVertex)
                    {
                        if ((!edges[j].oriented) || (vertexes[i] == edges[j].startVertex))
                            matrix[i, j] = edges[j].weight;
                        else if (vertexes[i] == edges[j].endVertex)
                            matrix[i, j] = -edges[j].weight;
                    }
                }
            }
            return matrix;
        }
        public int[,] AdjMatrix()
        {
            int[,] matrix = new int[vertexes.Length, vertexes.Length];
            for (int i = 0; i < edges.Length; i++)
            {
                matrix[edges[i].startVertex - 1, edges[i].endVertex - 1] = edges[i].weight;
                if (!edges[i].oriented)
                    matrix[edges[i].endVertex - 1, edges[i].startVertex - 1] = edges[i].weight;
                else
                    matrix[edges[i].endVertex - 1, edges[i].startVertex - 1] = -edges[i].weight;
            }
            return matrix;
        }
        public List<int> PathAbleVertexes(int vertex)
        {
            int[,] matrix = IncMatrix();
            List<int> incVertexes = new();
            for (int i = 0; i < edges.Length; i++)
            {
                if (matrix[vertex - 1, edges[i].number - 1] > 0)
                    incVertexes.Add(vertex == edges[i].endVertex ? edges[i].startVertex : edges[i].endVertex);
            }
            return incVertexes;
        }
        public static int[] SetVertexes()
        {
            int[] vertexes = new int[11];
            for (int i = 0; i < 11; i++)
                vertexes[i] = i + 1;
            return vertexes;
        }
        public Edge[,] EdgeMatrix()
        {
            int[,] adjMatrix = AdjMatrix();
            Edge[,] edgeMatrix = new Edge[adjMatrix.GetLength(0), adjMatrix.GetLength(1)];
            for (var i = 0; i < edges.Length; i++)
            {
                edgeMatrix[edges[i].startVertex - 1, edges[i].endVertex - 1] = edges[i];
            }
            return edgeMatrix;
        }
        public static Edge[] SetEdges()
        {
            Edge[] edges = new Edge[17];
            edges[0] = new Edge(1, 3200, 7, 1, false);
            edges[1] = new Edge(2, 2400, 1, 4, false);
            edges[2] = new Edge(3, 2400, 1, 9, false);
            edges[3] = new Edge(4, 800, 4, 8, true);
            edges[4] = new Edge(5, 1600, 4, 9, false);
            edges[5] = new Edge(6, 1600, 4, 2, false);
            edges[6] = new Edge(7, 400, 9, 5, true);
            edges[7] = new Edge(8, 1600, 2, 9, false);
            edges[8] = new Edge(9, 1600, 9, 3, true);
            edges[9] = new Edge(10, 800, 5, 3, true);
            edges[10] = new Edge(11, 3200, 8, 5, false);
            edges[11] = new Edge(12, 3200, 8, 10, false);
            edges[12] = new Edge(13, 3200, 5, 10, false);
            edges[13] = new Edge(14, 1600, 10, 6, false);
            edges[14] = new Edge(15, 400, 2, 3, true);
            edges[15] = new Edge(16, 800, 2, 11, false);
            edges[16] = new Edge(17, 800, 6, 11, true);
            return edges;
        }
    }
}