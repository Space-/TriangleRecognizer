using System;
using System.Collections.Generic;
using System.Linq;

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

            var compoundTriangleType = new List<string>();

            if (IsTriangle())
            {
                foreach (var triangle in triangleType)
                {
                    if (triangle.Key())
                    {
                        compoundTriangleType.Add(triangle.Value);
                    }
                }

                return string.Join(",", compoundTriangleType);
            }

            return "not triangle";
        }

        private bool IsIsoscelesTriangle()
        {
            return _edges.GroupBy(e => e)
                .Select(g => new { EdgeLength = g.Key, EdgeCount = g.Count() })
                .Max(e => e.EdgeCount) >= 2;
        }

        private int SquareSumOfTwoShortEdges()
        {
            return _edges.OrderBy(e => e).Take(2).Select(e => e * e).Sum();
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
            return _edges.Distinct().Count() == 1;
        }

        private bool IsTriangle()
        {
            return _edges.Length == 3 && _edges.OrderBy(e => e).Take(2).Sum() > _edges.Max();
        }
    }
}