using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    class Circle : RoundShape
    {
        public override double Perimeter() => 2*Math.PI*this.Radius;

        public Circle(Point center, double radius) : base(center, radius) {}
        public override void Output() 
        {
            Console.WriteLine("Это окружность: " +
                "\r\n   центр в точке: ({0},{1})," +
                "\r\n   радиус: {2}" +
                "\r\n   длина окружности: {3}", this.Center.X, this.Center.Y, this.Radius, this.Perimeter());
        }
               
    }  
    
}
