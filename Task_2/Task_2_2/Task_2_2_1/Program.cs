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
            Field field = StartGame(20, 20);
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
                    if (field.GridField[i, j] is Tree)
                        Console.Write('%');
                    if (field.GridField[i, j] is CherryBon)
                        Console.Write('o');
                    if (field.GridField[i, j] is AppleBon)
                        Console.Write('d');
                    if (field.GridField[i, j] is Wolf)
                        Console.Write('W');
                    if (field.GridField[i, j] is Bear)
                        Console.Write('B');
                    if (field.GridField[i, j] is null) 
                        Console.Write(' ');
                }
                Console.WriteLine();
            }            
        }
        public static Field StartGame(int width, int height)
        {
            Field field = new Field(width, height);
            field.MakeBorder();
            field.CreateTreeObstracle();
            field.CreateItem(TypeOfItem.CherryBon);
            field.CreateItem(TypeOfItem.AppleBon);
            field.CreateItem(TypeOfItem.Wolf);
            field.CreateItem(TypeOfItem.Bear);           

            return field;
        }
    }
}
