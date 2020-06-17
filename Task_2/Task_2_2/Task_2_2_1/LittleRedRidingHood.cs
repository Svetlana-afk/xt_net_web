using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public class LittleRedRidingHood : Character
    {   
        int Health { get; set; }
        public LittleRedRidingHood(int x, int y, int speed, int health, Field field) : base(x, y, speed, field) 
        {
            Health = health;
        }
        public void ChangeSpeed(int bonus)
        {
            Speed += bonus;
        }
        public void ChangeHealth(int bonus)
        {
            Health += bonus;
        }
    }

    

}
