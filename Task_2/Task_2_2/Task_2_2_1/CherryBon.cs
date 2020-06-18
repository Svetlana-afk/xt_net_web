using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public class CherryBon : Bonus
    {
        public int SpeedUp { get; set; }        
        public CherryBon(int speedUp, int x, int y, Field field) : base(x, y, field)
        {
            SpeedUp = speedUp;
        }
        public override void Print()
        {
            Console.Write('o');
        }
    }
}
