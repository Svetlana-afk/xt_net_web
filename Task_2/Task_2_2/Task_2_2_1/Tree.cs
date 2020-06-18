using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public class Tree : Obstacle
    {
        public Tree(int x, int y, Field field) : base(x, y, field) { }
        public override void Print()
        {
            Console.Write('%');
        }
    }
    
}
