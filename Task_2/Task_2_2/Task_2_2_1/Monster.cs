using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public abstract class Monster : Character
    {
        public int Power { get; set;}
        public Monster(int x, int y, Field field) : base(x, y, field) { }
        public override void Print()
        {
            Console.Write('*');
        }

        private bool _Move(int x, int y) 
        {
            if ((Field.GridField[x, y] is LittleRedRidingHood))
            {
                ((LittleRedRidingHood)Field.GridField[x, y]).DecreaseHealth(Power);
                return false;
            }

            if (!(Field.GridField[x, y] is Obstacle || Field.GridField[x, y] is Monster))
            {
                Field.GridField[this.X, this.Y] = null;
                this.X = x;
                this.Y = y;
                Field.GridField[this.X, this.Y] = this;
                return true;
            }
            return false;
        }
        
        public override void Move(Direction direction) 
        {
            switch (direction)
            {               
                case (Direction.Left):
                    if (_Move(this.X - 1, this.Y)) 
                    {
                        break;
                    }
                    goto case Direction.Up;
                case (Direction.Up):
                    if (_Move(this.X, this.Y - 1))
                    {
                        break;
                    }
                    goto case Direction.Right;                   
                case (Direction.Right):
                    if (_Move(this.X + 1, this.Y))
                    {
                        break;
                    }
                    goto case Direction.Down;
                case (Direction.Down):
                    if (_Move(this.X, this.Y + 1))
                    {
                        break;
                    }
                    goto case Direction.Left;
            }
        }        
    }
}
