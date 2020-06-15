using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public abstract class Monster : Character
    {
        public Monster(int x, int y, Field field) : base(x, y, field) { }
    }
}
