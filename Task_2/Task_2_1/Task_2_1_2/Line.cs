using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    class Line : OpenPolygonalShape
    {
        private const int COUNT_VERTICES = 1;
        public Line(Point center, double length) : base(center, COUNT_VERTICES)
        {

            Sides[0] = new Side(length);
        }

        public override double Length() => this.Sides[0].Length;
        public override string GetInfo()
        {
            return string.Format("Линия: " +
                    "\r\n   центр в точке: ({0},{1})," +
                    "\r\n   длина: {2}", this.Center.X, this.Center.Y, this.Sides[0].Length);
        }
    }
}
