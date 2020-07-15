using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_3_3
{
    public class Customer
    {
        public Customer(string name) 
        {
            Name = name;
        }
        public string Name { get; set; }
        public bool EatPizzaWithPleasure(Pizza pizza)
        { 
            return PizzaTypes.Margarita == pizza.PizzaType; 
        }
    }
}
