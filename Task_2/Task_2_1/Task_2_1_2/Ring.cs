using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    class Ring : Disk
    {
        public double InnerRadius{get; private set;}
        public Ring(Point center, double radius, double innerRadius) : base(center, radius)
        {
            if (innerRadius > 0 && innerRadius<this.Radius)
            {
                InnerRadius = innerRadius;
            }
            else
            {
                throw new Exception("Внуторенний радиус кольца должен быть положительным числом и меньше внешнего радиуса");
            }
        }
        public override double Length() => 2 * Math.PI * this.Radius + 2 * Math.PI * this.InnerRadius;
        public override double GetArea() => base.GetArea() - InnerRadius*InnerRadius*Math.PI;

        public override string GetInfo()
        {
            return String.Format("Кольцо: " +
                    "\r\n   центр в точке: ({0},{1})," +
                    "\r\n   внешний радиус: {2}" +
                    "\r\n   внутренний радиус:{3}" +
                    "\r\n   суммарная длина окружностей: {4}" +
                    "\n\r   площадь: {5}", this.Center.X, this.Center.Y, this.Radius, this.InnerRadius, this.Length(), this.GetArea());
        }
    }
}
