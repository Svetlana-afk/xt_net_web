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
            int a;
            int b;
            int c;

            Console.WriteLine("Введите значение длины стороны А прямоугольника");
            String astr = Console.ReadLine();
            a = Int16.Parse(astr);
            Console.WriteLine("Введите значение длины стороны B прямоугольника");
            String bstr = Console.ReadLine();
            b = Int16.Parse(bstr);
            c = rectangleSquare(a, b);
            Console.WriteLine(c);

        }

        static int rectangleSquare(int a, int b)
        {
            if (a <= 0)
            {
                Console.WriteLine("Неверное значение A, число должно быть больше 0");
                return -1;
            }

            if (b <= 0)
            {
                Console.WriteLine("Неверное значение B, число должно быть больше 0");
                return -1;
            }

            return a * b;
        }
    }
}
