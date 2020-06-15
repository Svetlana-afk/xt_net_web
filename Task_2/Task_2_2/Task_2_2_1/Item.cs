using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    abstract class Item
    {
        protected int X { get; set; }
        protected int Y { get; set; }

        Field field;

        public Item(int x, int y, Field field) 
        {
            if (x >= 0 && x < field.Width)
            {
                this.X = x;
            }
            else throw new ArgumentException("Координаты должны быть больше ноля и укладываться в размер игрового поля");

            if (y >= 0 && x < field.Height)
            {
                this.Y = y;
            }
            else throw new ArgumentException("Координаты должны быть больше ноля и укладываться в размер игрового поля");
            
        }
    }
} 