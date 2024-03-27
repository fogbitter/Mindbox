using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureService.Models
{
    public class RightAngledTriangle : Triangle
    {
        public override string Name => "RightAngledTriangle";
        internal RightAngledTriangle(double shortSide1, double shortSide2, double hipotenuse) 
            : base(shortSide1, shortSide2, hipotenuse)
        {
        }

        public override double GetArea()
        {
            return this.Side1 * this.Side2 / 2;
        }

        public static bool IsTriagleRightAngled(double side1, double side2, double side3)
        {
            double side1Square = side1 * side1;
            double side2Square = side2 * side2;
            double side3Square = side3 * side3;
            return side1Square + side2Square == side3Square
                || side1Square + side3Square == side2Square
                || side2Square + side3Square == side1Square
                ? true : false;
        }

        public override string ToString()
        {
            return $"{this.Name}, shortSide1 {this.Side1}, shortSide2 {this.Side2}, hipotenuse {this.Side3}";
        }
    }
}
