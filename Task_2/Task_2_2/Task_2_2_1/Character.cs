using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    abstract class Character : Item
    {
        public Character(int x, int y, Field field) : base(x, y, field) { }
        protected abstract void Move(Direction direction);
    }
}
