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
        public static Field StartGame(int width, int height)
        {
            int direction;

            Random rand = new Random();
            int direct;            
            
            Field field = new Field(width, height);
            Item rh = field.CreateItem(TypeOfItem.LittleRedRidingHood);
            field.MakeBorder();            
            field.CreateTreeObstracle();
            field.CreateItem(TypeOfItem.CherryBon);
            field.CreateItem(TypeOfItem.AppleBon);
            Wolf wolf = (Wolf)field.CreateItem(TypeOfItem.Wolf);
            field.CreateItem(TypeOfItem.Bear);
            
            while (true)
            {                
                PrintGridField(field);
                direct = rand.Next(1, 4);
                switch(direct)
                {
                    case (1):
                        if (!(field.GridField[wolf.X - 1, wolf.Y] is Obstacle))
                        {
                            field.GridField[wolf.X, wolf.Y] = null;
                            wolf.Move((Direction)direct);
                            field.GridField[wolf.X, wolf.Y] = wolf;
                            break;
                        }
                        else 
                        {
                            direct = 2;
                            goto case 2;
                        }                            
                       
                    case (2):
                        if (!(field.GridField[wolf.X, wolf.Y - 1] is Obstacle))
                        {
                            field.GridField[wolf.X, wolf.Y] = null;
                            wolf.Move((Direction)direct);
                            field.GridField[wolf.X, wolf.Y] = wolf;
                            break;
                        }
                        else 
                        {
                            direct = 3;
                            goto case 3;
                        }
                            

                    case (3):
                        if (!(field.GridField[wolf.X+1, wolf.Y] is Obstacle))
                        {
                            field.GridField[wolf.X, wolf.Y] = null;
                            wolf.Move((Direction)direct);
                            field.GridField[wolf.X, wolf.Y] = wolf; break;
                        }
                        else
                        {
                            direct = 4;
                            goto case 4;
                        }
                    case (4):
                        if (!(field.GridField[wolf.X, wolf.Y+1] is Obstacle))
                        {
                            field.GridField[wolf.X, wolf.Y] = null;
                            wolf.Move((Direction)direct);
                            field.GridField[wolf.X , wolf.Y] = wolf; 
                            break;
                        }
                        else
                        {
                            direct = 1;
                            goto case 1;
                        }
                }
                System.Threading.Thread.Sleep(500);
                Console.Clear();  
            }

            return field;
        }        
    }
}
