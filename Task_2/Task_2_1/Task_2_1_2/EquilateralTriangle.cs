using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    class EquilateralTriangle : ClosedPolygonalShape, IFillable
    {
        //for simplicity, consider an equilateral triangle
        private const int COUNT_VERTICES = 3;
        public EquilateralTriangle(Point center, double sideA) : base(center, COUNT_VERTICES)
        {
            this.Sides[0] = new Side(sideA);
            this.Sides[1] = new Side(sideA);
            this.Sides[2] = new Side(sideA);
        }

        public override double Perimeter() => 3 * this.Sides[0].Length;
        public double GetArea() => (Math.Sqrt(3)/4)*this.Sides[0].Length;
        public override string GetInfo()
        {
            return String.Format("Равносторонний треугольник: " +
                    "\r\n   центр в точке: ({0},{1})," +
                    "\r\n   сторона: a = {2}" +
                    "\r\n   периметр: {3}" +
                    "\n\r   площадь: {4}", this.Center.X, this.Center.Y, this.Sides[0].Length, this.Perimeter(), this.GetArea());
        }
    }
}
