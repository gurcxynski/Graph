using System.Collections.Generic;
using System.Linq;
using Priority_Queue;

namespace GraphNamespace
{
    internal class Dijkstra
    {
        Graph calculatedGraph;
        private Dictionary<int, int> lenghts;

        public Dijkstra(Graph calculatedGraph)
        {
            this.calculatedGraph = calculatedGraph;
            lenghts = new Dictionary<int, int>();
        }
        public void Reset(Graph calculatedGraph)
        {
            this.calculatedGraph = calculatedGraph;
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
        public Dictionary<int, int> MainAlgorithm(int source)
        {
            SimplePriorityQueue<int> priorityQueue = new SimplePriorityQueue<int>();
            InitiateLenghts(source);
            priorityQueue.Enqueue(source, 0);
            while (priorityQueue.Any())
            {

                int operatedVertex = priorityQueue.First();
                priorityQueue.Dequeue();
                foreach (var item in calculatedGraph.vertices[operatedVertex].outgoingEdges)
                {
                    int newLenght = lenghts[operatedVertex] + item.Value;
                    if (lenghts[item.Key] > newLenght)
                    {
                        lenghts[item.Key] = newLenght;
                        priorityQueue.Enqueue(item.Key, newLenght);
                    }
                }
            }
            return lenghts;
        }
    }
}
