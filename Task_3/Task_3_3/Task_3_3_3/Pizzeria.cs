using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_3_3
{
    class Pizzeria
    {
        Dictionary<Order, Pizza> complateOrders = new Dictionary<Order, Pizza>();

        public event EventHandler PizzaReadyToEat;

        protected virtual void OnPizzaReadyToEat(ReadyToEatEventArgs e)
        {
            EventHandler handler = PizzaReadyToEat;
            handler?.Invoke(this, e);
        }

        public Order MakeOrder(String customer, PizzaTypes pizzaType) 
        {
            Order order = new Order(customer, pizzaType);
            MakePizzaAsync(order);
            return order;
        }

        private async Task MakePizzaAsync(Order order)
        {
            await Task.Delay(2000);
            Pizza pizza = new Pizza(order.PizzaType);
            order.IsСompleted = true;
            complateOrders.Add(order, pizza);
            OnPizzaReadyToEat(new ReadyToEatEventArgs(order));
        }

        public Pizza GetPizza(Order order)
        {
            if (order.IsСompleted) 
            {
                Pizza pizza = null;
                complateOrders.TryGetValue(order, out pizza);
                complateOrders.Remove(order);
                return pizza;
            }
            return null;
        }
    }    
}
