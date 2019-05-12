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

        [Test]
        public void Three_Edges_sam_but_greater_than_zero_return_right_triangle()
        {
            const int edge1 = 3;
            const int edge2 = 3;
            const int edge3 = 3;

            Assert.AreEqual("regular triangle", GetTriangleIdentificationResult(edge1, edge2, edge3));
        }

        private string GetTriangleIdentificationResult(params int[] edges)
        {
            if (IsTriangle(edges))
            {
                if (IsRegularTriangle(edges))
                {
                    return "regular triangle";
                }
            }

            return "not triangle";
        }

        private bool IsRegularTriangle(int[] edges)
        {
            for (var i = 0; i < edges.Length - 1; i++)
            {
                if (edges[i] != edges[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsTriangle(int[] edges)
        {
            Array.Sort(edges);
            return edges.Length == 3 && edges.Where(e => e <= edges.Max()).Sum() > edges.Max();
        }
    }
}