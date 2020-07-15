using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_3_3
{
    class ReadyToEatEventArgs : EventArgs
    {
        public Order CompleteOrder { get; set; }

        public ReadyToEatEventArgs(Order order) 
        {
            CompleteOrder = order;
        }
    }
}
