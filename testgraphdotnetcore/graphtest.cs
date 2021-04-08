using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphNamespace;
using System.Collections.Generic;

namespace testgraphdotnetcore
{
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void GraphAdding()
        {
            Graph graph = new Graph();
            graph.Add(0);
            graph.Add(1);
            graph.Add(2);
            graph.Add(-5);
            Dictionary<int, int> score = new Dictionary<int, int>();
            score.Add(0, 0);
            score.Add(1, 1);
            score.Add(2, 2);
            score.Add(3, -5);
            foreach (var item in graph.vertices.Values)
            {
                Assert.AreEqual(item.GetVertexValue(), score[item.vertexID]);
            }
        }

        [TestMethod]
        public void GraphRemoving()
        {
            Graph graph = new Graph();
            graph.Add(0);
            graph.Add(1);
            graph.Add(2);
            graph.RemoveAtIndex(1);
            graph.RemoveAtIndex(1);
            Assert.AreEqual(1, graph.vertices.Count);
        }

        [TestMethod]
        public void GraphLinking()
        {
            Graph graph = new Graph();
            graph.Add(0);
            graph.Add(1);
            graph.Add(2);
            Assert.IsTrue(graph.Link(0, 1, 3));
            Assert.IsTrue(graph.Link(0, 2, 2));
            Assert.IsTrue(graph.Link(1, 2, -4));
            Assert.IsFalse(graph.Link(14, -123, 0));
        }

        [TestMethod]
        public void GraphUnlinking()
        {
            Graph graph = new Graph();
            graph.Add(0);
            graph.Add(1);
            graph.Add(2);
            graph.Link(0, 1, 3);
            graph.Link(0, 2, 2);
            graph.Link(1, 2, -4);
            Assert.IsTrue(graph.Unlink(0, 1));
            Assert.IsTrue(graph.Unlink(0, 2));
            Assert.IsFalse(graph.Unlink(-12, 21344));
        }

    }
}
