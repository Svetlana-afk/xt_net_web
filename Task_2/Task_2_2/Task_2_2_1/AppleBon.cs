using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    class AppleBon : Bonus
    {
        int ForceUp { get; set;}
        public AppleBon(int forceUp) 
        {
            ForceUp = forceUp;
        }
    }
}
