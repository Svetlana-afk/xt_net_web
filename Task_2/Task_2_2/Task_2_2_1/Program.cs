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
            Field field = new Field(20, 20);
            StartGame(field);
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
                    if (field.GridField[i, j] is LittleRedRidingHood)
                        Console.Write('*');
                    if (field.GridField[i, j] is null) 
                        Console.Write(' ');                    
                }
                Console.WriteLine();
            }            
        }
        public static void StartGame(Field field)
        {
            Random rand = new Random();
            int direct; 
            
            LittleRedRidingHood redHood = (LittleRedRidingHood)field.CreateItem(TypeOfItem.LittleRedRidingHood);
            field.MakeBorder();            
            field.CreateTreeObstracle();
            field.CreateItem(TypeOfItem.CherryBon);
            field.CreateItem(TypeOfItem.AppleBon);
            Wolf wolf = (Wolf)field.CreateItem(TypeOfItem.Wolf);
            Bear bear = (Bear)field.CreateItem(TypeOfItem.Bear);
            
            while (true)
            {                
                PrintGridField(field);
                direct = rand.Next(1, 4);
                wolf.Move((Direction)direct);
                direct = rand.Next(1, 4);
                bear.Move(((Direction)direct));                
                System.Threading.Thread.Sleep(500);
                Console.Clear();  
            }
        }        
    }
}
