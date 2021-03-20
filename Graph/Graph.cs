using System;
using System.Collections.Generic;

namespace Graph
{
    class Vertex
    {
        private int vertexValue;
        public readonly int vertexID;
        public HashSet<int> incomingEdges;
        public HashSet<int> outgoingEdges;
        public Vertex(int value, int ID)
        {
            vertexValue = value;
            vertexID = ID;
            incomingEdges = new HashSet<int>();
            outgoingEdges = new HashSet<int>();
        }
        public int GetNodeValue()
        {
            return vertexValue;
        }
        public void Link(Vertex vertexArgument)
        {
            outgoingEdges.Add(vertexArgument.vertexID);
            vertexArgument.incomingEdges.Add(vertexID);
        }
        public int getNodeIndex()
        {
            outgoingEdges.Remove(nodeArgument.vertexID);
            nodeArgument.incomingEdges.Remove(vertexID);
        }
    }
    class Graph : IEnumerable<Node>
    {
        public Dictionary<int, Vertex> vertices;
        private int nextID;
        public Graph()
        {
            vertices = new Dictionary<int, Vertex>();
            nextID = 0;
        }
        public bool Link(int a, int b)
        {
            if (vertices.ContainsKey(a) && vertices.ContainsKey(b))
            {
                Vertex from = vertices[a];
                Vertex to = vertices[b];
                from.Link(to);
                return true;
            }
            return false;
        }
        public bool Unlink(int a, int b)
        {
            if (vertices.ContainsKey(a) && vertices.ContainsKey(b))
            {
                Vertex from = vertices[a];
                Vertex to = vertices[b];
                from.UnLink(to);
                return true;
            }
            return false;
        }
        public int Add(int value)
        {
            nodes.Add(new Node(a));
            lenght++;
            nodes[nodes.Count - 1].borders = new List<int>();
            return nodes[nodes.Count - 1];
        }
        public void RemoveAtIndex(int removedIndex)
        {
            if (!vertices.ContainsKey(a)) return;
            Vertex nodeToRemove = vertices[a];
            foreach (var item in nodeToRemove.outgoingEdges)
            {
                nodeToRemove.UnLink(vertices[item]);
            }
            foreach (var item in nodeToRemove.incomingEdges)
            {
                if (item.getNodeIndex() == a) nodes.Remove(item);
            }
            lenght--;
        }
        public void RemoveNumber(int removedNumber)
        {
            foreach (var item in nodes)
            {
                if (item.getNodeValue() == removedNumber)
                {
                    nodes.Remove(item);
                    return;
                }
            }
            lenght--;
        }
        public IEnumerator<Node> GetEnumerator()
        {
            return new GraphEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GraphEnumerator(this);
        }
    }
    class GraphEnumerator : IEnumerator<Node>
    {
        private Graph currentGraph;
        private Node currentNode;
        public Node Current
        {
            get
            {
                if (currentNode == null)
                {
                    return default(Node);
                }
                else
                {
                    return currentNode;
                }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if (currentNode == null)
                {
                    return default(Node);
                }
                else
                {
                    return currentNode;
                }
            }
        }

        public GraphEnumerator(Graph graphArgument)
        {
            currentGraph = graphArgument;
            currentNode = default(Node);
        }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (currentNode == default(Node))
            {
                if (currentGraph.nodes.Count != 0)
                {
                    currentNode = currentGraph.nodes[0];
                    return true;
                }
                else return false;
            }
            if (currentNode.getNodeIndex() < currentGraph.nodes.Count - 1)
            {
                currentNode = currentGraph.nodes[currentNode.getNodeIndex() + 1];
                return true;
            }
            return false;
        }

        public void Reset()
        {
            currentNode = default(Node);
        }
    }
}
