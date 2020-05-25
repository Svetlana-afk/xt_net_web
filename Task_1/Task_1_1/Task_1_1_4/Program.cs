using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число строк N для построения X-Mas Tree");
            string strRowСount = Console.ReadLine();
            byte rowСount = byte.Parse(strRowСount);
            DrawXMasTree(rowСount);
        }
        static void DrawXMasTree(byte rowCount)
        {
            string starStr = "";
            for (int k = 1; k<=rowCount; k++)
            {
                for (int i = 1; i <= k; i++)
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
}
