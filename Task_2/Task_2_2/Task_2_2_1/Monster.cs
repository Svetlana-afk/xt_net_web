using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public abstract class Monster : Character
    {
        public int Power { get; set;}
        public Monster(int x, int y, Field field) : base(x, y, field) { }

        public override void Move(Direction direction) 
        {
            switch (direction)
            {
               
                case (Direction.Left):
                    if (!(Field.GridField[this.X - 1, this.Y] is Obstacle))
                    {
                        Field.GridField[this.X, this.Y] = null;
                        this.X -= 1;
                        Field.GridField[this.X, this.Y] = this;
                        break;
                    }
                    else
                    {
                        direction = Direction.Up;
                        goto case Direction.Up;
                    }

                case (Direction.Up):
                    if (!(Field.GridField[this.X, this.Y - 1] is Obstacle))
                    {
                        Field.GridField[this.X, this.Y] = null;
                        this.Y -= 1;
                        Field.GridField[this.X, this.Y] = this;
                        break;
                    }
                    else
                    {
                        direction = Direction.Right;
                        goto case Direction.Right;
                    }
                case (Direction.Right):
                    if (!(Field.GridField[this.X + 1, this.Y] is Obstacle))
                    {
                        Field.GridField[this.X, this.Y] = null;
                        this.X += 1;
                        Field.GridField[this.X, this.Y] = this;
                        break;
                    }
                    else
                    {
                        direction = Direction.Down;
                        goto case Direction.Down;
                    }
                case (Direction.Down):
                    if (!(Field.GridField[this.X, this.Y + 1] is Obstacle))
                    {
                        Field.GridField[this.X, this.Y] = null;
                        this.Y += 1;
                        Field.GridField[this.X, this.Y] = this;
                        break;
                    }
                    else
                    {
                        direction = Direction.Left;
                        goto case Direction.Left;
                    }
            }
        }
    }
}
