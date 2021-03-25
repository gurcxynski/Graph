using System;

namespace Graph
{
    class Program
    {
        static void Main()
        {
            Graph graf = new Graph();
            graf.Add(0);
            graf.Add(1);
            graf.Add(2);
            graf.Add(3);
            graf.Add(4);
            graf.Add(5);
            graf.Link(0, 1, 3);
            graf.Link(1, 2, 1);
            graf.Link(2, 5, 1);
            graf.Link(2, 3, 3);
            graf.Link(3, 1, 3);
            graf.Link(5, 0, 6);
            graf.Link(0, 4, 3);
            graf.Link(4, 5, 2);
            graf.Link(5, 3, 1);
            graf.Dijkstra(0);
            foreach (var item in graf.lenghts.Keys)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            foreach (var item in graf.lenghts.Values)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Graph graf2 = new Graph();
            graf2.Add(1);
            graf2.Add(2);
            graf2.Add(3);
            graf2.Add(4);
            graf2.Add(5);
            graf2.Link(0, 1, 2);
            graf2.Link(0, 3, 4);
            graf2.Link(1, 3, 3);
            graf2.Link(1, 2, 3);
            graf2.Link(2, 4, 2);
            graf2.Link(3, 2, 3);
            graf2.Link(3, 4, 4);
            graf2.Dijkstra(0);
            foreach (var item in graf2.lenghts.Keys)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            foreach (var item in graf2.lenghts.Values)
            {
                Console.Write(item);
            }
        }
    }
}
