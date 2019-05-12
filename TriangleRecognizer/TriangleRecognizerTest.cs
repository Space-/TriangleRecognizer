using System;
using System.Linq;
using NUnit.Framework;

namespace TriangleRecognizerTest
{
    public class TriangleRecognizerTest
    {
        [Test]
        public void Two_Edges_sum_Less_Than_Max_Edge_return_not_triangle()
        {
            const int edge1 = 1;
            const int edge2 = 2;
            const int edge3 = 0;

            Assert.AreEqual("not triangle", GetTriangleIdentificationResult(edge1, edge2, edge3));
        }

        private string GetTriangleIdentificationResult(params int[] edges)
        {
            return IsTriangle(edges) ? "" : "not triangle";
        }

        private bool IsTriangle(int[] edges)
        {
            Array.Sort(edges);
            return edges.Length == 3 && edges.Where(e => e < edges.Max()).Sum() > edges.Max();
        }
    }
}