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
        public void CreateRockObstracle() 
        {
            Random random = new Random();
            for (int i = 0; i < (this.Height*this.Width)/20; i++)
            {
                Rock rock = new Rock(random.Next(2, this.Width - 2), random.Next(2, this.Height - 2), this);
                GridField[rock.X, rock.Y] = rock;
            }
        }
        public void CreateCherryBonus()
        {
            Random random = new Random();
            int speedUp = 2;
            
            CherryBon cherry = new CherryBon(speedUp, random.Next(2, this.Width - 2), random.Next(2, this.Height - 2), this);
            GridField[cherry.X, cherry.Y] = cherry;
            
        }
    }
}
