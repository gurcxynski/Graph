using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Node
    {
        private int index;
        private int nodeValue;
        public List<int> borders;
        public Node(int a)
        {
            nodeValue = a;
        }
        public int getNodeValue()
        {
            return nodeValue;
        }
        public int getNodeIndex()
        {
            return index;
        }
    }
    class Graph
    {
        public int lenght;
        public List<Node> nodes;
        public Graph()
        {
            nodes = new List<Node>();
            lenght = 0;
        }
        public bool Link(int a, int b)
        {
            if (nodes[a] == null || nodes[b] == null || a == b) return false;
            nodes[a].borders.Add(b);
            return true;
        }
        public bool Unlink(int a, int b)
        {
            if (nodes[a] == null || nodes[b] == null || a == b) return false;
            if (!nodes[a].borders.Remove(b)) return false;
            return true;
        }
        public Node Add(int a)
        {
            nodes.Add(new Node(a));
            lenght++;
            nodes[nodes.Count - 1].borders = new List<int>();
            return nodes[nodes.Count - 1];
        }
        public void Remove(int a)
        {
            foreach (var item in nodes)
            {
                if (item.getNodeIndex() == a) nodes.Remove(item);
            }
            lenght--;
        }
    }
}
