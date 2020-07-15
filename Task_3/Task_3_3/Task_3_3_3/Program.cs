using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_3_3
{
    class Program
    {
        public static Pizzeria MyPubPizzeria;
        public static Customer me;
        static void Main(string[] args)
        {
            Console.WriteLine("Pizzeria has Opened.");
            MyPubPizzeria = new Pizzeria();
            MyPubPizzeria.PizzaReadyToEat += c_PizzaIsReadyToEat;
            me = new Customer("Sveta");
            Order order = MyPubPizzeria.MakeOrder(me.Name, PizzaTypes.Margarita);
            Console.WriteLine("Sveta has ordered Pizza Margarita.");
            System.Threading.Thread.Sleep(6000);
        }

        static void c_PizzaIsReadyToEat(object sender, EventArgs e)
        {
            ReadyToEatEventArgs rte = (ReadyToEatEventArgs)e;
            Console.WriteLine("Pizza is ready for: " + rte.CompleteOrder.CustomerName);
            Pizza pizza = MyPubPizzeria.GetPizza(rte.CompleteOrder);
            bool ifLikeIt = me.EatPizzaWithPleasure(pizza);
            Console.WriteLine("I like it: " + ifLikeIt);
        }
    }
}
