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
        public void UnLink(Vertex nodeArgument)
        {
            outgoingEdges.Remove(nodeArgument.vertexID);
            nodeArgument.incomingEdges.Remove(vertexID);
        }
    }
    class Graph
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
            Vertex temp = new Vertex(value, nextID);
            vertices.Add(nextID, temp);
            nextID++;
            return temp.vertexID;
        }
        public void Remove(int a)
        {
            if (!vertices.ContainsKey(a)) return;
            Vertex nodeToRemove = vertices[a];
            foreach (var item in nodeToRemove.outgoingEdges)
            {
                nodeToRemove.UnLink(vertices[item]);
            }
            foreach (var item in nodeToRemove.incomingEdges)
            {
                vertices[item].UnLink(nodeToRemove);
            }
            vertices.Remove(a);
        }
    }
}
