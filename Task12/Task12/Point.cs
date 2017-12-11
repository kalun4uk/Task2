using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace Task12
{
    class Point
    {
        /// <summary>
        /// Initialization of object Point
        /// </summary>
        public int xValue { get; set; }
        public int yValue { get; set; }

        /// <summary>
        /// Initilize coordinates of point
        /// </summary>
        /// <param name="x">X-coordinate value</param>
        /// <param name="y">Y-coordinate value</param>
        public Point(int x, int y)
        {
            xValue = x;
            yValue = y;
        }

        /// <summary>
        /// Verification operator overlod
        /// </summary>
        /// <param name="a">Object of class Point</param>
        /// <param name="b">>Object of class Point</param>
        /// <returns>Bool value as a result of verification</returns>
        public static bool operator == (Point a, Point b)
        {
            return a.xValue == b.xValue && a.yValue == b.yValue;
        }

        /// <summary>
        /// Verification operator overlod
        /// </summary>
        /// <param name="a">Object of class Point</param>
        /// <param name="b">>Object of class Point</param>
        /// <returns>Bool value as a result of verification</returns>
        public static bool operator !=(Point a, Point b)
        {
            return !(a.xValue == b.xValue) || !(a.yValue == b.yValue);
        }
    }
}
