using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    class LittleRedRidingHood : Character
    {
        
        public LittleRedRidingHood(int x, int y, Field field) : base(x, y, field) { }
        protected override void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left: this.X += 1; break;
                case Direction.Up: this.Y += 1; break;
                case Direction.Right: this.X -= 1; break;
                case Direction.Down: this.Y -= 1; break;
                case Direction.None: break;
            }
        }
    }

}
