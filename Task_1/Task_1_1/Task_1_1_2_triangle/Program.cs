using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_1_2_triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число строк N для построения прямогугольного треуголька звездочками");
            string strRowСount = Console.ReadLine();
            byte rowСount = byte.Parse(strRowСount);
            DrawTriangle(rowСount);
        }
        static void DrawTriangle(byte rowCount)
        {
            string starStr = "";
            for (int i = 1; i <= rowCount; i++)
            {
                starStr = starStr + "*";
                Console.WriteLine(starStr);
            }
        }
    }
}
