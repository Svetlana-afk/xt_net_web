using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    //abstraction allows you to add any polygonal shapes
    abstract class PolygonalShape : Shape
    {   
        public Side[] Sides { get; set; }
        public PolygonalShape(Point center, int countOfVertices) : base(center) 
        {
            Sides = new Side[countOfVertices];
        }
    }    
}
