using System.Collections;
using System.Collections.Generic;

namespace Graph
{
    class Vertex
    {
        private int vertexValue;
        public readonly int vertexID;
        public Dictionary<int, int> incomingEdges;
        public Dictionary<int, int> outgoingEdges;
        public Vertex(int value, int ID)
        {
            vertexValue = value;
            vertexID = ID;
            incomingEdges = new Dictionary<int, int>();
            outgoingEdges = new Dictionary<int, int>();
        }
        public int GetVertexValue()
        {
            return vertexValue;
        }
        public void Link(Vertex vertexArgument, int value)
        {
            outgoingEdges.Add(vertexArgument.vertexID, value);
            vertexArgument.incomingEdges.Add(vertexID, value);
        }
        public void UnLink(Vertex vertexArgument)
        {
            outgoingEdges.Remove(vertexArgument.vertexID);
            vertexArgument.incomingEdges.Remove(vertexID);
        }
    }
    class Graph: IEnumerable<Vertex>
    {
        public Dictionary<int, Vertex> vertices;
        private int nextID;

        public Graph()
        {
            vertices = new Dictionary<int, Vertex>();
            nextID = 0;
        }
        public int getID()
        {
            return nextID;
        }
        public bool Link(int firstEdge, int secondEdge, int value)
        {
            if (vertices.ContainsKey(firstEdge) && vertices.ContainsKey(secondEdge))
            {
                Vertex from = vertices[firstEdge];
                Vertex to = vertices[secondEdge];
                from.Link(to, value);
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
            vertices[nextID] = new Vertex(value, nextID);
            int temp = nextID;
            nextID++;
            return temp;
        } 
        public void RemoveAtIndex(int removedIndex)
        {
            if (vertices.ContainsKey(removedIndex))
            {
                vertices.Remove(removedIndex);
                if (removedIndex != vertices.Count - 1)
                {
                    vertices.Add(removedIndex, vertices[removedIndex + 1]);
                    for (int i = removedIndex + 1; i < vertices.Count - 1; i++)
                    {
                        vertices[i] = vertices[i + 1];
                    }
                    vertices.Remove(vertices.Count - 1);
                }
                nextID--;
            }
        }

        public IEnumerator<Vertex> GetEnumerator()
        {
            return new GraphEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GraphEnumerator(this);
        }
    }
    class GraphEnumerator : IEnumerator<Vertex>
    {
        private Graph currentGraph;
        private Vertex currentVertex;
        public Vertex Current
        {
            get
            {
                if (currentVertex == null)
                {
                    return null;
                }
                else
                {
                    return currentVertex;
                }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if (currentVertex == null)
                {
                    return null;
                }
                else
                {
                    return currentVertex;
                }
            }
        }
        public GraphEnumerator(Graph graphArgument)
        {
            currentGraph = graphArgument;
            currentVertex = null;
        }

        public bool MoveNext()
        {
            if (currentVertex == null)
            {
                currentVertex = currentGraph.vertices[0];
                return true;
            }
            else if (currentVertex.vertexID < currentGraph.vertices.Count - 1) 
            {
                currentVertex = currentGraph.vertices[currentVertex.vertexID + 1];
                return true;
            }
            return false;
        }

        public void Reset()
        {
            currentVertex = null;
        }

        public void Dispose()
        {

        }
    }
}
