using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FigureService.Models
{
    public class Triangle : BaseFigure
    {
        public const string Invalid = "Invalid Triangle";
        public override string Name => "Triangle";
        public double Side1 { get; init; }
        public double Side2 { get; init; }
        public double Side3 { get; init; }
        internal Triangle(double side1, double side2, double side3)
        {
            if (!IsValidTriagle(side1,side2,side3))
            {
                throw new Exception(Invalid);
            }
            
            this.Side1 = side1;
            this.Side2 = side2;
            this.Side3 = side3;
        }

        public override double GetArea()
        {
            double halfPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - this.Side1) * (halfPerimeter - this.Side2) * (halfPerimeter - this.Side3));
        }

        public static bool IsValidTriagle(double side1, double side2, double side3)
        {
            return side1 > 0 && side2 > 0 && side3 > 0 && side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
        }

        public override double GetPerimeter()
        {
            return this.Side1 + this.Side2 + this.Side3;
        }

        public override string ToString()
        {
            return $"{this.Name}, Side1 {this.Side1}, Side2 {this.Side2}, Side3 {this.Side3}";
        }
    }
}
