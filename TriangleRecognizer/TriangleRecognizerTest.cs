using NUnit.Framework;

namespace TriangleRecognizerTest
{
    public class TriangleRecognizerTest
    {
        public int[] Edges { get; private set; }
        private TriangleRecognizer _triangleRecognizer;

        [Test]
        public void Two_Edges_sum_Less_Than_Max_Edge_and_some_edges_are_zero_return_not_triangle()
        {
            GivenEdges(1, 2, 0);
            GivenTriangleRecognizer();

            Assert.AreEqual("not triangle", _triangleRecognizer.GetTriangleIdentificationResult());
        }

        [Test]
        public void Three_Edges_same_but_greater_than_zero_return_regular_triangle()
        {
            GivenEdges(3, 3, 3);
            GivenTriangleRecognizer();

            Assert.AreEqual("regular triangle,isosceles triangle,acute triangle", _triangleRecognizer.GetTriangleIdentificationResult());
        }

        [Test]
        public void Pythagorean_theorem_return_right_triangle()
        {
            GivenEdges(3, 4, 5);
            GivenTriangleRecognizer();

            Assert.AreEqual("right triangle", _triangleRecognizer.GetTriangleIdentificationResult());
        }

        [Test]
        public void Two_Edges_sum_Less_Than_Max_Edge_and_all_edges_not_zero_return_obtuse_triangle()
        {
            GivenEdges(9, 11, 17);
            GivenTriangleRecognizer();

            Assert.AreEqual("obtuse triangle", _triangleRecognizer.GetTriangleIdentificationResult());
        }

        [Test]
        public void Two_Edges_sum_Greater_Than_Max_Edge_and_all_edges_not_zero_return_acute_triangle()
        {
            GivenEdges(5, 6, 7);
            GivenTriangleRecognizer();

            Assert.AreEqual("acute triangle", _triangleRecognizer.GetTriangleIdentificationResult());
        }

        [TestCase(5, 4, 4, "isosceles triangle,acute triangle")]
        [TestCase(4, 5, 5, "isosceles triangle,acute triangle")]
        [TestCase(4, 4, 5, "isosceles triangle,acute triangle")]
        [TestCase(3, 3, 5, "isosceles triangle,obtuse triangle")]
        public void Two_Edges_same_and_its_sum_greater_than_third_edge_and_all_edges_not_zero_return_isosceles_triangle(int edge1, int edge2, int edge3, string triangleType)
        {
            GivenEdges(edge1, edge2, edge3);
            GivenTriangleRecognizer();

            Assert.AreEqual(triangleType, _triangleRecognizer.GetTriangleIdentificationResult());
        }

        private void GivenEdges(params int[] edges)
        {
            Edges = edges;
        }

        private void GivenTriangleRecognizer()
        {
            _triangleRecognizer = new TriangleRecognizer(Edges);
        }
    }
}