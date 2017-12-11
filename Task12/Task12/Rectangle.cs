using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task12
{
    partial class Rectangle
    {
        Point[] points = new Point[4];

        public Rectangle() { }

        public Rectangle(Point a1, Point a2 , Point a3 , Point a4 )
        {
            points[0] = a1;
            points[1] = a2;
            points[2] = a3;
            points[3] = a4;
        }

        
    }
}
