using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureService.Models
{
    public abstract class BaseFigure
    {
        public virtual string Name => "BaseFigure";
        internal BaseFigure()
        {

        }
        public abstract double GetArea();
        public abstract double GetPerimeter();

        public override string ToString()
        {
            return this.Name;
        }
    }
}
