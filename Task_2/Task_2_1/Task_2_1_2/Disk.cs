using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    class Disk : Circle, IFillable
    {
        public Disk(Point center, double radius) : base(center, radius) { }
        public virtual double GetArea() => this.Radius * this.Radius * Math.PI;

        public override string GetInfo()
        {
            return String.Format("Круг: " +
                        "\r\n   центр в точке: ({0},{1})," +
                        "\r\n   радиус: {2}" +
                        "\r\n   длина окружности: {3}" +
                        "\n\r   площадью: {4}", this.Center.X, this.Center.Y, this.Radius, this.Length(),this.GetArea());
        }

    }
}
