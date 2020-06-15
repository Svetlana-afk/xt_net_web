using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_1
{
    class Walls
    {
        List<Obstacle> walls = new List<Obstacle>();
        public Walls(Field field)
        {
            for (int i = 0; i < field.Width; i++)
            {
                Rock rock = new Rock(i, 0, field);
                walls.Add(rock);
            }
            for (int i = 0; i < field.Width; i++)
            {
                Rock rock = new Rock(i, field.Width-1, field);
                walls.Add(rock);
            }
            for (int i = 0; i < field.Height; i++)
            {
                Rock rock = new Rock(0, i, field);
                walls.Add(rock);
            }
            for (int i = 0; i < field.Height; i++)
            {
                Rock rock = new Rock(field.Height -1, i, field);
                walls.Add(rock);
            }
        }
    }
}
