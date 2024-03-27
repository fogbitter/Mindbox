using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureService.Models
{
    public class Circle : BaseFigure
    {
        public const string Invalid = "Invalid Circle";
        public override string Name => "Circle";
        public double Radius { get; init; }
        internal Circle(double radius)
        {
            if (!IsValidCircle(radius))
            {
                throw new Exception(Invalid);
            }
            this.Radius = radius;
        }

        public override double GetArea()
        {
            return this.Radius * this.Radius * Math.PI;
        }

        public override double GetPerimeter()
        {
            return 2 * this.Radius * Math.PI;
        }

        public static bool IsValidCircle(double radius)
        {
            return radius > 0;
        }

        public override string ToString()
        {
            return $"{this.Name}, Radius {this.Radius}";
        }
    }
}
