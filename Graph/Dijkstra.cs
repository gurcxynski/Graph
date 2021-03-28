using System.Collections.Generic;

namespace Graph
{
    internal class Dijkstra
    {
        Graph calculatedGraph;
        private HashSet<int> counted;
        private HashSet<int> notCounted;
        private Dictionary<int, int> lenghts;

        public Dijkstra(Graph calculatedGraph)
        {
            this.calculatedGraph = calculatedGraph;
            counted = new HashSet<int>();
            notCounted = new HashSet<int>();
            lenghts = new Dictionary<int, int>();
        }
        public void Reset(Graph calculatedGraph)
        {
            this.calculatedGraph = calculatedGraph;
            counted = new HashSet<int>();
            notCounted = new HashSet<int>();
            lenghts = new Dictionary<int, int>();
        }

        private void InitiateLenghts(int source)
        {
            lenghts.Add(source, 0);
            for (int i = 0; i < calculatedGraph.getID(); i++)
            {
                if (i != source)
                {
                    lenghts.Add(i, int.MaxValue);
                }

            }
        }
        private void InitiatePriorityList()
        {
            for (int i = 0; i < calculatedGraph.getID(); i++)
            {
                notCounted.Add(i);
            }
        }
        public Dictionary<int,int> MainAlgorithm(int source)
        {
            InitiateLenghts(source);
            InitiatePriorityList();
            while (notCounted.Count != 0)
            {
                int minValue = int.MaxValue;
                foreach (var item in notCounted)
                {
                    if (item < minValue) minValue = item;
                }
                notCounted.Remove(minValue);
                counted.Add(minValue);
                foreach (var item in calculatedGraph.vertices[minValue].outgoingEdges)
                {
                    if (lenghts[item.Key] > (lenghts[minValue] + item.Value))
                    {
                        lenghts[item.Key] = (lenghts[minValue] + item.Value);
                    }
                }
            }
            return lenghts;
        }
    }
}