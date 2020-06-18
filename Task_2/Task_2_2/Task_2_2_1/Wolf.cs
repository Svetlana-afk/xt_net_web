using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public class Wolf : Monster
    {
        public Wolf(int x, int y, Field field) : base(x, y, field) 
        {
            Speed = 3;
            Power = 1;
        }
        public override void Print()
        {
            Console.Write('W');
        }
    }
}
