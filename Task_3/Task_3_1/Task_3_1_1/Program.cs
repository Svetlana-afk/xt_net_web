using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_1_1
{
    class Program
    {
        static void Main(string[] args)
        {  
            var counting = new Counting();
            
            counting.NumberOfParticipants = GetN();
            counting.GenerateCircleOfPeople();
            Console.WriteLine("Сгенерирован круг людей из {0} человек.", counting.NumberOfParticipants); 
            counting.NumberToCrossedOut = GetStep(counting.NumberOfParticipants);
            counting.MakeCounting2();            
            Console.WriteLine("После считалочки осталось:");
            counting.PrintCircleOfPeople();  
        }
        public static int GetN() 
        {
            int n = 0;
            bool succes = false;
            while (!succes)
            {
                Console.WriteLine("Введите N:");
                if (int.TryParse(Console.ReadLine(), out n) && (n > 0))
                {
                    succes = true;
                }
                else
                {
                    Console.WriteLine("N должно быть положительным числом.");
                }
            }
            return n;
        }
        public static int GetStep(int n) 
        {
            int step = 0;
            bool succes = false;
            while (!succes)
            {
                Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд:");
                if (int.TryParse(Console.ReadLine(), out step) && (step > 0))
                {
                    if (step <= n)
                    {
                        succes = true;
                    }
                    else
                    {
                        Console.WriteLine("Это число должно быть не больше N. ");
                    }
                }
                else
                {
                    Console.WriteLine("N должно быть положительным числом.");
                }
            }
            return step;
        }
    }
}
