using System;
using System.Collections.Generic;
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
            var triangleType = new Dictionary<Func<bool>, string>
            {
                {IsRegularTriangle, "regular triangle"},
                {IsRightTriangle, "right triangle"},
                {IsIsoscelesTriangle, "isosceles triangle"},
                {IsObtuseTriangle, "obtuse triangle"},
                {IsAcuteTriangle, "acute triangle"}
            };

            if (IsTriangle())
            {
                foreach (var triangle in triangleType)
                {
                    if (triangle.Key())
                    {
                        return triangle.Value;
                    }
                }
            }

            return "not triangle";
        }

        private bool IsIsoscelesTriangle()
        {
            return _edges.GroupBy(e => e)
                         .Select(g => new { EdgeLength = g.Key, EdgeCount = g.Count() })
                         .Max(e => e.EdgeCount) == 2;
        }

        private int SquareSumOfTwoShortEdges()
        {
            return _edges.Where(e => e < _edges.Max()).Select(e => e * e).Sum();
        }

        private int SquareSumOfMaximumEdge()
        {
            return _edges.Max() * _edges.Max();
        }

        private bool IsAcuteTriangle()
        {
            return SquareSumOfTwoShortEdges() > SquareSumOfMaximumEdge();
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
            return _edges.Length == 3 && _edges.OrderBy(e => e).Take(2).Sum() > _edges.Max();
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
        public void Two_Edges_sum_Greater_Than_Max_Edge_and_all_edges_not_zero_return_acute_triangle()
        {
            const int edge1 = 5;
            const int edge2 = 6;
            const int edge3 = 7;

            var triangleRecognizer = new TriangleRecognizer(edge1, edge2, edge3);
            Assert.AreEqual("acute triangle", triangleRecognizer.GetTriangleIdentificationResult());
        }

        [TestCase(5, 4, 4)]
        [TestCase(4, 5, 5)]
        [TestCase(4, 4, 5)]
        public void Two_Edges_same_and_its_sum_greater_than_third_edge_and_all_edges_not_zero_return_isosceles_triangle(int edge1, int edge2, int edge3)
        {
            var triangleRecognizer = new TriangleRecognizer(edge1, edge2, edge3);
            Assert.AreEqual("isosceles triangle", triangleRecognizer.GetTriangleIdentificationResult());
        }
    }
}