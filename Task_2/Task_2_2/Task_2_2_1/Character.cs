using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public abstract class Character : Item
    {
        public int Speed {get; set;}

        public Character(int x, int y, Field field) : base(x, y, field) { }
        
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left: this.X -= 1; break;
                case Direction.Up: this.Y = Y - 1; break;
                case Direction.Right: this.X += 1; break;
                case Direction.Down: this.Y += 1; break;
                case Direction.None: break;
            }
        }        
    }
}
