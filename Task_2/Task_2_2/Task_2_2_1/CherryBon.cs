using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    class CherryBon : Bonus
    {
        int SpeedUp { get; set; }
        public CherryBon(int speedUp)
        {
            SpeedUp = speedUp;
        }

    }
}
