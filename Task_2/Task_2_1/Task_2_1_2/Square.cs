using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    class Square: PolygonalShape
    {
        private const int COUNT_VERTICES = 4;
        public Square(Point center, double side) : base(center, COUNT_VERTICES)
        {
            this.Sides[0] = new Side(side);
            this.Sides[1] = new Side(side);
            this.Sides[2] = new Side(side);
            this.Sides[3] = new Side(side);
        }

        public override double Perimeter() => COUNT_VERTICES * this.Sides[0].Length;
        public double GetArea() => this.Sides[0].Length* this.Sides[0].Length;
        public override void Output()
        {
            Console.WriteLine("Квадрат: " +
                "\r\n   центр в точке: ({0},{1})" +
                "\r\n   сторона: a = {2}" +
                "\r\n   периметр: {3}" +
                "\n\r   площадь: {4}", this.Center.X, this.Center.Y, this.Sides[0].Length, this.Perimeter(), this.GetArea());
        }
    }
}
