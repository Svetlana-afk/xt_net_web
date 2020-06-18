using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public class AppleBon : Bonus
    {
        public int HealthUp { get; set;}
        public AppleBon(int healthUp, int x, int y, Field field) : base(x, y, field)        
        {
            HealthUp = healthUp;
        }
        public override void Print()
        {
            Console.Write('d');
        }
    }
}
