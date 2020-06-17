using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public class Field
    {
        public int Width { get; set;}
        public int Height { get; set;}
        public Item[,] GridField;
        
        public Field(int widht, int height) 
        {
            Width = widht;
            Height = height;
            GridField = new Item[Width, Height];           
        }
        public void MakeBorder() 
        {           
            for (int i = 0; i < Width; i++)
            {
                Rock rock = new Rock(i, 0, this);
                GridField[i, 0] = rock;     
            }            
            for (int i = 0; i < Width; i++)
            {
                Rock rock = new Rock(i, Height, this);
                GridField[i, Height -1] = rock;               
            }            
            for (int i = 1; i < Height-1; i++)
            {
                Rock rock = new Rock(0, i, this);
                GridField[0, i] = rock;
            }
            for (int i = 1; i < Height-1; i++)
            {
                Rock rock = new Rock(Width, i, this);
                GridField[Width-1, i] = rock;
            }  
        }
        public void CreateTreeObstracle() 
        {            
            for (int i = 0; i < (this.Height*this.Width)/20; i++)
            {
                CreateItem(TypeOfItem.Tree);
            }
        }
        
        public Item CreateItem(TypeOfItem type)
        {
            Random random = new Random();
            int x = 0;
            int y = 0;
            while (GridField[x, y] != null)
            {
                x = random.Next(2, this.Width - 2);
                y = random.Next(2, this.Height - 2);
            }
            switch (type) 
            {
                case (TypeOfItem.Tree):
                    Tree tree = new Tree(x, y, this);
                    GridField[tree.X, tree.Y] = tree;
                    return tree;
                case (TypeOfItem.Rock):
                    Rock rock = new Rock(x, y, this);
                    GridField[rock.X, rock.Y] = rock;
                    return rock;
                case (TypeOfItem.CherryBon):
                    int speedUp = 1;
                    CherryBon cherry = new CherryBon(speedUp, x, y, this);
                    GridField[cherry.X, cherry.Y] = cherry;
                    return cherry;
                case (TypeOfItem.AppleBon):
                    int healthUp = 1;
                    AppleBon apple = new AppleBon(healthUp, x, y, this);
                    GridField[apple.X, apple.Y] = apple;
                    return apple;
                case (TypeOfItem.Wolf):
                    Wolf wolf = new Wolf(x, y, 3, 1, this);
                    GridField[wolf.X, wolf.Y] = wolf;
                    return wolf;
                case (TypeOfItem.Bear):
                    Bear bear = new Bear(x, y, 3, 1, this);
                    GridField[bear.X, bear.Y] = bear;
                    return bear;
                
                default: return null;
            }            
        }

    }
}
