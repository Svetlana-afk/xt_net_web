using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public abstract class Monster : Character
    {
        int Power { get; set;}
        public Monster(int x, int y, int speed, int power, Field field) : base(x, y, speed, field) 
        {
            Power = power;
        }
    }
}
