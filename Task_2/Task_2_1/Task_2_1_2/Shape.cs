using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    public abstract class Shape
    {
        public Point Center{ get; set;}
        public Shape(Point center)
        {
            Center = center;
        }

        public abstract double Perimeter();

        public virtual void Output() { }
    }
}
