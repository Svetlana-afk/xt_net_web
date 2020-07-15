using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_3_3
{
    public class Pizza
    {
        public PizzaTypes PizzaType { get; set; }
        public int PreparingTime { get; set; }

        public Pizza(PizzaTypes pizzaType) 
        {
            PizzaType = pizzaType;
        }
    }
    public enum PizzaTypes
    {
        Margarita,
        QuattroFormaggi
    }
}
