using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    public abstract class Item
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Field Field { get; set; }

        public Item(int x, int y, Field field) 
        {
            Field = field;
            if (x >= 0 && x <= field.Width)
            {
                this.X = x;
            }
            else throw new ArgumentException("Координаты должны быть больше ноля и укладываться в размер игрового поля");

            if (y >= 0 && y <= field.Height)
            {
                this.Y = y;
            }
            else throw new ArgumentException("Координаты должны быть больше ноля и укладываться в размер игрового поля");
            
        }
    }
} 