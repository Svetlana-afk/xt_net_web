using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public class Bear : Monster
    {
        public Bear(int x, int y, int speed, int power, Field field) : base(x, y, speed, power, field) { }
    }
}
