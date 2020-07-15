using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_3_3
{
    class Order
    {
        //Customer customer { get; set; }
        //List<Pizza> pizzas { get; }
        public string CustomerName { get; }
        public PizzaTypes PizzaType { get; }
        public bool IsСompleted { get; set; } = false;

        public Order(String name, PizzaTypes PizzaType)
        {
            CustomerName = name;
            this.PizzaType = PizzaType;
        }
    }
}
