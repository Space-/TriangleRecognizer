using System;
using System.Linq;
using NUnit.Framework;

namespace TriangleRecognizerTest
{
    public class TriangleRecognizer
    {
        private readonly int[] _edges;

        public TriangleRecognizer(params int[] edges)
        {
            _edges = edges;
        }

        public string GetTriangleIdentificationResult()
        {
            if (IsTriangle())
            {
                if (IsRegularTriangle())
                {
                    return "regular triangle";
                }
            }

            return "not triangle";
        }

        private bool IsRegularTriangle()
        {
            for (var i = 0; i < _edges.Length - 1; i++)
            {
                if (_edges[i] != _edges[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsTriangle()
        {
            Array.Sort(_edges);
            return _edges.Length == 3 && _edges.Where(e => e <= _edges.Max()).Sum() > _edges.Max();
        }
    }

    public class TriangleRecognizerTest
    {
        [Test]
        public void Two_Edges_sum_Less_Than_Max_Edge_return_not_triangle()
        {
            const int edge1 = 1;
            const int edge2 = 2;
            const int edge3 = 0;

            var triangleRecognizer = new TriangleRecognizer(edge1, edge2, edge3);
            Assert.AreEqual("not triangle", triangleRecognizer.GetTriangleIdentificationResult());
        }

        [Test]
        public void Three_Edges_same_but_greater_than_zero_return_regular_triangle()
        {
            const int edge1 = 3;
            const int edge2 = 3;
            const int edge3 = 3;

            var triangleRecognizer = new TriangleRecognizer(edge1, edge2, edge3);
            Assert.AreEqual("regular triangle", triangleRecognizer.GetTriangleIdentificationResult());
        }
    }
}