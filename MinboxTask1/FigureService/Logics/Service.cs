using FigureService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace FigureService.Logics
{
    public class Service
    {
        public static bool NeedThrowException = false;
        public static BaseFigure GetCircle(double radius)
        {
            if (!Circle.IsValidCircle(radius))
            {
                return ThrowExceptionIfNeed(Circle.Invalid);
            }
            return new Circle(radius);
        }
        public static BaseFigure GetTriangle(double side1, double side2, double side3)
        {
            if (!Triangle.IsValidTriagle(side1,side2,side3))
            {
                return ThrowExceptionIfNeed(Triangle.Invalid);
            }
            if (RightAngledTriangle.IsTriagleRightAngled(side1,side2,side3))
            {
                (double shortSide1, double shortSide2, double hypotenuse) = GetTwoSidesAndHypotenuse(side1, side2, side3);
                return new RightAngledTriangle(shortSide1, shortSide2, hypotenuse);
            }
            return new Triangle(side1, side2, side3);
        }

        public static (double, double, double) GetTwoSidesAndHypotenuse(double side1, double side2, double side3)
        {
            List<double> sides = new List<double> { side1, side2, side3 };
            sides.Sort();
            return (sides[0],sides[1], sides[2]);
        }

        public static EmptyFigure ThrowExceptionIfNeed(string message)
        {
            if(NeedThrowException)
            {
                throw new Exception(message);
            }
            return new EmptyFigure();
        }
    }
}
