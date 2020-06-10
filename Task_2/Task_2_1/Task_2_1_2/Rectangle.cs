using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    class Rectangle : ClosedPolygonalShape, IFillable
    {
        private const int COUNT_VERTICES = 4;
        public Rectangle(Point center, double sideA, double sideB ) : base(center, COUNT_VERTICES)
        {
            this.Sides[0] = new Side(sideA);
            this.Sides[1] = new Side(sideB);
            this.Sides[2] = new Side(sideA);
            this.Sides[3] = new Side(sideB);
        }

        public override double Perimeter() => 2 * this.Sides[0].Length + 2 * this.Sides[1].Length;
        public double GetArea() => this.Sides[0].Length * this.Sides[1].Length;

        public override string GetInfo()
        {
            return String.Format("Прямоугольник: " +
                    "\r\n   центр в точке: ({0},{1})," +
                    "\r\n   стороны: a = {2}, b = {3}" +
                    "\r\n   периметр: {4}" +
                    "\n\r   площадь: {5}", this.Center.X, this.Center.Y, this.Sides[0].Length, this.Sides[1].Length, this.Perimeter(), this.GetArea());
        }
    }
   

}
