using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureService.Models
{
    public class EmptyFigure : BaseFigure
    {
        public override string Name => "EmptyFigure";
        public override double GetArea()
        {
            return 0;
        }

        public override double GetPerimeter()
        {
            return 0;
        }
    }
}
