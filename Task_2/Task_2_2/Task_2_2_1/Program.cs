using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field(20, 15);
            field.MakeBorder();
            field.CreateRockObstracle();
            field.CreateCherryBonus();
            PrintGridField(field);            
        }        
        public static void PrintGridField(Field field)
        {
            for (int j = 0; j < field.Height; j++)
            {
                for (int i = 0; i < field.Width; i++)
                {
                    if (field.GridField[i, j] is Rock)
                        Console.Write('#');
                    else if (field.GridField[i, j] is CherryBon)
                        Console.Write('o');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
