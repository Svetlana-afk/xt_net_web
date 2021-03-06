﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    abstract class RoundShape : Shape
    {       
        public double Radius { get; protected set; }

        public RoundShape(Point center, double radius) : base(center)
        {
            Radius = radius;
            if (radius > 0)
            {
                Radius = radius;
            }
            else
            {
                throw new Exception("Радиус должен быть положительным числом.");
            }
        }

        public abstract double Length();
    }
}
