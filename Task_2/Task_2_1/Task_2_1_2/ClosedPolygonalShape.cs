using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    abstract class ClosedPolygonalShape : PolygonalShape
    {
        public ClosedPolygonalShape(Point center, int countOfVertices) : base(center, countOfVertices) {}

        public abstract double Perimeter();
    }
}
