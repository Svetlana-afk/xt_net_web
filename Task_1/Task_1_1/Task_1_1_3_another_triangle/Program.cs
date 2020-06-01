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
            bool succes = false;
            int rowСount = -1;


            while (!succes || rowСount <= 0)
            {
                Console.WriteLine("Введите число строк N для построения треуголька звездочками");
                succes = Int32.TryParse(Console.ReadLine(), out rowСount);
            }
            
            DrawAnotherTriangle(rowСount);
        }
        static void DrawAnotherTriangle(int rowCount)
        {
            StringBuilder starStr = new StringBuilder ("", rowCount);
            for (int i = 1; i <= rowCount; i++)
            {               
                starStr.Append(' ', rowCount -i);
                
                starStr.Append('*', 2*i -1);
               
                Console.WriteLine(starStr);
                starStr.Clear();
            }
        }
    }
}
