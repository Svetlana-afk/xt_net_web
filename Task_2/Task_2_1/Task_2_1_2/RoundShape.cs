using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    abstract class RoundShape : Shape
    {       
        public double Radius { get; set; }

        public RoundShape(Point center, double radius) : base(center)
        {
            Radius = radius;
        }       

    }
}
