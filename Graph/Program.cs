using System;
using System.Collections.Generic;

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
            Dijkstra calculator = new Dijkstra(graf);
            Dictionary<int, int> answer1 =  calculator.MainAlgorithm(0);
            calculator.Reset(graf2);
            Dictionary<int, int> answer2 = calculator.MainAlgorithm(0);
            foreach (var item in answer1)
            {
                Console.Write(item.Key);
            }
            Console.WriteLine();
            foreach (var item in answer1)
            {
                Console.Write(item.Value);
            }
            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in answer2)
            {
                Console.Write(item.Key);
            }
            Console.WriteLine();
            foreach (var item in answer2)
            {
                Console.Write(item.Value);
            }
            Console.WriteLine();
        }
    }
}
