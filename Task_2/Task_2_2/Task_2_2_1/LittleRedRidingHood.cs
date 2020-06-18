using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public  class LittleRedRidingHood : Character
    {
        public int Health { get; private set; }
        public LittleRedRidingHood(int x, int y, Field field) : base(x, y,  field) 
        {
            Speed = 2;
            Health = 5;
        }
        private void _Move(int x, int y) 
        {            
            if (Field.GridField[x, y] is null)
            {
                Field.GridField[this.X, this.Y] = null;
                this.X = x;
                this.Y = y;
                Field.GridField[this.X, this.Y] = this;
                return;
            }
            if (Field.GridField[x, y] is Monster) 
            {
                this.DecreaseHealth(((Monster)Field.GridField[x, y]).Power);
                return;
            }
            if (Field.GridField[x, y] is Bonus)
            {
                this.EatBonus((Bonus)Field.GridField[x, y]);
                Field.GridField[this.X, this.Y] = null;
                this.X = x;
                this.Y = y;
                Field.GridField[this.X, this.Y] = this;
                return;
            }
        }
        public void EatBonus(Bonus bonus) 
        {
            if (bonus is AppleBon) 
            {
                this.IncreaseHealth(((AppleBon)bonus).HealthUp);
            }
            if (bonus is CherryBon)
            {
                this.IncreaseSpeed(((CherryBon)bonus).SpeedUp);
            }
        }
        public void EatBonus(CherryBon cherry)
        {
            this.IncreaseSpeed(cherry.SpeedUp);
        }
        private void IncreaseSpeed(int count)
        {
            Speed += count;
        }
        private void IncreaseHealth(int count)
        {
            Health += count;
        }
        public void DecreaseHealth(int count) 
        {
            Health -= count;
        }
        public bool IsAlive() 
        {
            if (Health > 0) 
            {
                return true;
            }
            return false;
        }
        public override void  Move(Direction direction) 
        {
            switch (direction)
            {
                case (Direction.Left):
                    _Move(this.X - 1, this.Y);
                    break;
                case (Direction.Up):
                    _Move(this.X, this.Y - 1);
                    break;
                case (Direction.Right):
                    _Move(this.X + 1, this.Y);
                    break;
                case (Direction.Down):
                    _Move(this.X, this.Y + 1);
                    break;
            }

        }
    }   

}
