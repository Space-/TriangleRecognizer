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

                if (IsRightTriangle())
                {
                    return "right triangle";
                }

                if (IsObtuseTriangle())
                {
                    return "obtuse triangle";
                }

                if (IsAcuteTriangle())
                {
                    return "acute triangle";
                }
            }

            return "not triangle";
        }

        private bool IsAcuteTriangle()
        {
            return SquareSumOfTwoShortEdges() > SquareSumOfMaximumEdge();
        }

        private int SquareSumOfTwoShortEdges()
        {
            return _edges.Where(e => e < _edges.Max()).Select(e => e * e).Sum();
        }

        private int SquareSumOfMaximumEdge()
        {
            return _edges.Max() * _edges.Max();
        }

        private bool IsObtuseTriangle()
        {
            return SquareSumOfTwoShortEdges() < SquareSumOfMaximumEdge();
        }

        private bool IsRightTriangle()
        {
            return SquareSumOfTwoShortEdges() == SquareSumOfMaximumEdge();
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
            return _edges.Length == 3 && _edges.All(e => e > 0) && _edges.Where(e => e <= _edges.Max()).Sum() > _edges.Max();
        }
    }

    public class TriangleRecognizerTest
    {
        [Test]
        public void Two_Edges_sum_Less_Than_Max_Edge_and_some_edges_are_zero_return_not_triangle()
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

        [Test]
        public void Pythagorean_theorem_return_right_triangle()
        {
            const int edge1 = 3;
            const int edge2 = 4;
            const int edge3 = 5;

            var triangleRecognizer = new TriangleRecognizer(edge1, edge2, edge3);
            Assert.AreEqual("right triangle", triangleRecognizer.GetTriangleIdentificationResult());
        }

        [Test]
        public void Two_Edges_sum_Less_Than_Max_Edge_and_all_edges_not_zero_return_obtuse_triangle()
        {
            const int edge1 = 9;
            const int edge2 = 11;
            const int edge3 = 17;

            var triangleRecognizer = new TriangleRecognizer(edge1, edge2, edge3);
            Assert.AreEqual("obtuse triangle", triangleRecognizer.GetTriangleIdentificationResult());
        }

        [Test]
        public void Two_Edges_sum_Greater_Than_Max_Edge_and_all_edges_not_zero_return_obtuse_triangle()
        {
            const int edge1 = 5;
            const int edge2 = 6;
            const int edge3 = 7;

            var triangleRecognizer = new TriangleRecognizer(edge1, edge2, edge3);
            Assert.AreEqual("acute triangle", triangleRecognizer.GetTriangleIdentificationResult());
        }
    }
}