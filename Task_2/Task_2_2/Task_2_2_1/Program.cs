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
                    if (field.GridField[i, j] is null)
                    {
                        Console.Write(' ');
                    }
                    else
                    { 
                        field.GridField[i, j].Print(); 
                    }              
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
            CherryBon cherry = (CherryBon)field.CreateItem(TypeOfItem.CherryBon);
            AppleBon apple = (AppleBon)field.CreateItem(TypeOfItem.AppleBon);
            Wolf wolf = (Wolf)field.CreateItem(TypeOfItem.Wolf);
            Bear bear = (Bear)field.CreateItem(TypeOfItem.Bear);
            
            while (true)
            {                
                if (cherry.IsEated())
                {
                    cherry = (CherryBon)field.CreateItem(TypeOfItem.CherryBon);
                }
                if (apple.IsEated())
                {
                    apple = (AppleBon)field.CreateItem(TypeOfItem.AppleBon);
                }               
                if (Console.KeyAvailable) 
                {                                        
                    ConsoleKeyInfo key = Console.ReadKey();
                        switch (key.Key) 
                    {
                        case ConsoleKey.LeftArrow:
                            redHood.Move(Direction.Left);
                            break;
                        case ConsoleKey.UpArrow:
                            redHood.Move(Direction.Up);
                            break;
                        case ConsoleKey.RightArrow:
                            redHood.Move(Direction.Right);
                            break;
                        case ConsoleKey.DownArrow:
                            redHood.Move(Direction.Down);
                            break;
                    }
                }
                Console.WriteLine("Жизней у Красной Шапочки:{0}", redHood.Health);
                PrintGridField(field);
                direct = rand.Next(1, 4);
                wolf.Move((Direction)direct);
                direct = rand.Next(1, 4);
                bear.Move((Direction)direct);
                System.Threading.Thread.Sleep(500);
                Console.Clear();
                if (!redHood.IsAlive())
                {
                    Console.Clear();
                    Console.WriteLine("                GAME OVER");
                    break;
                }
            }
        }        
    }
}
