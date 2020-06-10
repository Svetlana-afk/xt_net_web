using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    abstract class OpenPolygonalShape : PolygonalShape
    {
        public OpenPolygonalShape(Point center, int countOfVertices) : base(center, countOfVertices) {}

        public abstract double Length();

    }
}
