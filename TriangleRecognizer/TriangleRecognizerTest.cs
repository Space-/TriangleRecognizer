using NUnit.Framework;

namespace TriangleRecognizerTest
{
    public class TriangleRecognizerTest
    {
        public int[] Edges { get; private set; }

        [Test]
        public void Two_Edges_sum_Less_Than_Max_Edge_and_some_edges_are_zero_return_not_triangle()
        {
            GivenEdges(1, 2, 0);

            var triangleRecognizer = new TriangleRecognizer(1, 2, 0);
            Assert.AreEqual("not triangle", triangleRecognizer.GetTriangleIdentificationResult());
        }

        private void GivenEdges(params int[] edges)
        {
            Edges = edges;
        }

        [Test]
        public void Three_Edges_same_but_greater_than_zero_return_regular_triangle()
        {
            const int edge1 = 3;
            const int edge2 = 3;
            const int edge3 = 3;

            var triangleRecognizer = new TriangleRecognizer(edge1, edge2, edge3);
            Assert.AreEqual("regular triangle,isosceles triangle,acute triangle", triangleRecognizer.GetTriangleIdentificationResult());
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

        [TestCase(5, 4, 4, "isosceles triangle,acute triangle")]
        [TestCase(4, 5, 5, "isosceles triangle,acute triangle")]
        [TestCase(4, 4, 5, "isosceles triangle,acute triangle")]
        [TestCase(3, 3, 5, "isosceles triangle,obtuse triangle")]
        public void Two_Edges_same_and_its_sum_greater_than_third_edge_and_all_edges_not_zero_return_isosceles_triangle(int edge1, int edge2, int edge3, string triangleType)
        {
            var triangleRecognizer = new TriangleRecognizer(edge1, edge2, edge3);
            Assert.AreEqual(triangleType, triangleRecognizer.GetTriangleIdentificationResult());
        }
    }
}