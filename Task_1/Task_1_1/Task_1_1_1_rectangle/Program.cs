using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_1_1_rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=-1;
            int b=-1;
            int c;
            bool succesA = false;
            bool succesB = false;

           
            while (!succesA || a <= 0) 
            {
                Console.WriteLine("Введите значение длины стороны А прямоугольника:");
                succesA = Int32.TryParse(Console.ReadLine(), out a);
            }

            while (!succesB || b <= 0)
            {
                Console.WriteLine("Введите значение длины стороны B прямоугольника:");
                succesB = Int32.TryParse(Console.ReadLine(), out b);
            }

            c = rectangleSquare(a, b);
            Console.WriteLine("Площадь прямоугольника {0}", c);
            return;
          
        }

        static int rectangleSquare(int a, int b)
        {
            if (a <= 0||b <= 0)
            {
                Console.WriteLine("Неверное значение одного из параметров, это должны быть числа больше 0");
                return -1;
            }
            return a * b;
        }
    }
}
