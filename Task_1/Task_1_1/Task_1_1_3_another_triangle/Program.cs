using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_1_3_another_triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число строк N для построения треуголька звездочками");
            string strRowСount = Console.ReadLine();
            byte rowСount = byte.Parse(strRowСount);
            DrawAnotherTriangle(rowСount);
        }
        static void DrawAnotherTriangle(byte rowCount)
        {
            string starStr = "";
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= rowCount - i; j++)
                {
                    starStr += " ";
                }
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    starStr += "*";
                }
                Console.WriteLine(starStr);
                starStr = "";
            }
        }
    }
}
