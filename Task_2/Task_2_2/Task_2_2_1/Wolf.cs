using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public class Wolf : Monster
    {
        public Wolf(int x, int y, int speed, int power, Field field) : base(x, y, speed, power, field) { }
    }
}
