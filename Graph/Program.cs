using System;

namespace Graph
{
    class Program
    {
        static void Main()
        {
            Graph graf = new Graph();
            graf.Add(2);
            graf.Add(5);
            graf.Add(21);
            Console.WriteLine(graf.Link(0, 1));
            Console.WriteLine(graf.Link(1, 2));
            Console.WriteLine(graf.Link(2, 0));
            Console.WriteLine(graf.Link(0, 0));
            Console.WriteLine(graf.Unlink(0, 1));
            Console.WriteLine(graf.Unlink(1, 2));
            Console.WriteLine(graf.Unlink(2, 0));
            Console.WriteLine(graf.Unlink(0, 2));
            Console.WriteLine(graf.Unlink(0, 0));
        }
    }
}
