using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_3_3
{
    class Order
    {
        Customer customer { get; set; }
        List<Pizza> pizzas { get; }
        bool IsСompleted = false;
    }
}
