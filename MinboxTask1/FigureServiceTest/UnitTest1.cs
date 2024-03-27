using FigureService.Logics;
using FigureService.Models;

namespace FigureServiceTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(-1, true)]
        [TestCase(0, true)]
        [TestCase(1, false)]
        public void Test_EmptyFigure_Circle(int radius, bool emptyFigure)
        {
            var figure = Service.GetCircle(radius);
            Assert.IsTrue(figure is EmptyFigure == emptyFigure);
        }
        [TestCase(-1, 0, 0, true)]
        [TestCase(0, 0, 0, true)]
        [TestCase(1, 0, 0, true)]
        [TestCase(1, 1, 0, true)]
        [TestCase(1, 0, 1, true)]
        [TestCase(1, 2, 3, true)]
        [TestCase(1, 2, 4, true)]
        [TestCase(1, 4, 4, false)]
        [TestCase(2, 3, 4, false)]
        public void Test_EmptyFigure_Triagle(int side1, int side2, int side3, bool emptyFigure)
        {
            var figure = Service.GetTriangle(side1, side2, side3);
            Assert.IsTrue(figure is EmptyFigure == emptyFigure);
        }

        [TestCase(1, 4, 4, false)]
        [TestCase(2, 3, 4, false)]
        [TestCase(3, 4, 5, true)]
        public void Test_RightAngledTriangle(int side1, int side2, int side3, bool rightAngled)
        {
            var figure = Service.GetTriangle(side1, side2, side3);
            Assume.That(figure is not EmptyFigure, () => "figure must not be emtpty");

            Assert.IsTrue(figure is RightAngledTriangle == rightAngled);
        }

        [TestCase(3, 4, 5, 5)]
        public void Test_RightAngledTriangle_Hypotenuse(int side1, int side2, int side3, int hypotenuse)
        {
            var figure = Service.GetTriangle(side1, side2, side3);
            Assume.That(figure is RightAngledTriangle, () => "figure must be RightAngledTriangle");

            var typedFigure = figure as RightAngledTriangle;            

            Assert.IsTrue(typedFigure.Side3 == hypotenuse);
        }

        [TestCase(3, 4, 5, 3, 4, 5, true)]
        [TestCase(3, 5, 4, 3, 4, 5, true)]
        [TestCase(5, 3, 4, 3, 4, 5, true)]
        [TestCase(5, 3, 4, 4, 3, 5, false)]
        [TestCase(3, 4, 5, 5, 3, 3, false)]
        public void Test_RightAngledTriangle_Sides(int side1, int side2, int side3, double shortSide1, double shortSide2, double hypotenuse, bool equal)
        {
            Assume.That(RightAngledTriangle.IsTriagleRightAngled(side1, side2, side3), () => "Must be right angled");

            (double shortSide1Test, double shortSide2Test, double hypotenuseTest) = Service.GetTwoSidesAndHypotenuse(side1, side2, side3);

            Assert.IsTrue((shortSide1 == shortSide1Test
                &&
                shortSide2 == shortSide2Test
                &&
                hypotenuse == hypotenuseTest) 
                == equal);
        }
    }
}