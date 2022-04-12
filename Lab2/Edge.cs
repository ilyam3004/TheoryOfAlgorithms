using System;

namespace Lab2
{
    public class Edge
    {
        public int weight;
        private int _flow;
        public int flow
        {
            get
            {
                return _flow;
            }
            set
            {
                if (value > _flow)
                    new Exception($"Edge №{number} flow {_flow} exceded edge weight {weight}!");
                _flow = value;
            }
        }
        public int number;
        public bool oriented;
        public int startVertex;
        public int endVertex;
        public Edge(int number, int weight, int startVertex, int endVertex, bool orientation)
        {
            this.number = number;
            this.startVertex = startVertex;
            this.endVertex = endVertex;
            this.weight = weight;
            this.oriented = orientation;
        }
    }
}