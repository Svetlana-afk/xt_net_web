using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public class Bear : Monster
    {
        public Bear(int x, int y, Field field) : base(x, y, field) 
        {
            Speed = 1;
            Power = 2;
        }
        public override void Print()
        {
            Console.Write('B');
        }
    }
}
