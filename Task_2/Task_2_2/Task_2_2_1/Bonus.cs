﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public abstract class Bonus : Item
    {
        public Bonus(int x, int y, Field field) : base(x, y, field) { }
    }
}
