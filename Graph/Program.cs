using System;

namespace Graph
{
    class Program
    {
        static void Main()
        {
            Graph graf = new Graph();
            graf.Add(1);
            graf.Add(2);
            graf.Add(3);
            graf.Add(4);
            graf.Add(5);
            graf.RemoveAtIndex(3);
            graf.RemoveAtIndex(3);
            foreach (var item in graf)
            {
                Console.WriteLine(item.GetVertexValue());
            }
        }
    }
}
