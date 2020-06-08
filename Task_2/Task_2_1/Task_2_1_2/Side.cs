using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    class Side
    {
        //if necessary add fields: the Start and End Points         
        public double Length { get; private set; }
        public Side(double length) 
        {
            if (length > 0)
            {
                this.Length = length;
            }
            else 
            {
                throw new Exception("Длина должна быть положительным числом.");
            }
            
        }
    }
}
