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
        public void ChangeSpeed(int bonus)
        {
            this.speed += bonus;
        }
        public void ChangePower(int bonus)
        {
            this.power += bonus;
        }
    }

    

}
