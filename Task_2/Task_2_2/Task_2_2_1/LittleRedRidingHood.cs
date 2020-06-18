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
        int Health { get; set; }
        public LittleRedRidingHood(int x, int y, Field field) : base(x, y,  field) 
        {
            Speed = 2;
            Health = 5;
        }
        public void ChangeSpeed(int count)
        {
            Speed += count;
        }
        public void IncreaseHealth(int count)
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
    }   

}
