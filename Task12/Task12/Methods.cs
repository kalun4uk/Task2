using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task12
{
    partial class Rectangle
    {
        /// <summary>
        /// Verification of the paralelism of the rectangle.
        /// </summary>
        /// <returns>Bool value if figure is rectangle</returns>
        public bool checkBasicsParallelism()
        {
            if (SamePoint()) return false;
            if ((points[0].xValue == points[1].xValue && points[1].yValue == points[2].yValue) && (points[2].xValue == points[3].xValue && points[0].yValue == points[3].yValue))
                return true;
            if ((points[0].xValue == points[2].xValue && points[1].yValue == points[3].yValue) && (points[2].xValue == points[3].xValue && points[0].yValue == points[3].yValue))
                return true;
            if ((points[0].xValue == points[1].xValue && points[1].yValue == points[2].yValue) && (points[2].xValue == points[3].xValue && points[0].yValue == points[3].yValue))
                return true;
            return false;
        }

        /// <summary>
        /// Verify of the point coordinates if they are on the same vector
        /// </summary>
        /// <returns>Bool value - the result of verification</returns>
        public bool SamePoint()
        {
            if (points[0] == points[1] || points[0] == points[2] || points[0] == points[3] || points[1] == points[2] || points[1] == points[3] || points[2] == points[3])
            {
                Console.WriteLine("This figure is not rectangle");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Change size of the rectangle using the number value
        /// </summary>
        /// <param name="rect">The object of the rectangle to change</param>
        /// <param name="size">The number change value</param>
        /// <returns>The rectangle</returns>
        public static Rectangle operator *(Rectangle rect, int size)
        {
            Rectangle rectangle = new Rectangle(new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0));
            rectangle.points[0].xValue = rect.points[0].xValue * size;
            rectangle.points[0].yValue = rect.points[0].yValue * size;
            rectangle.points[1].xValue = rect.points[1].xValue * size;
            rectangle.points[1].yValue = rect.points[1].yValue * size;
            rectangle.points[2].xValue = rect.points[2].xValue * size;
            rectangle.points[2].yValue = rect.points[2].yValue * size;
            rectangle.points[3].xValue = rect.points[3].xValue * size;
            rectangle.points[3].yValue = rect.points[3].yValue * size;
            return rectangle;
        }

        /// <summary>
        /// Get new smallest rectangle that consists of the two others
        /// </summary>
        /// <param name="first">One rectangle</param>
        /// <returns>new rectangle that consist of two others</returns>
        public Rectangle NewTwoGetRect(Rectangle first)
        {
            Rectangle second = this;
            int maxX = first.points.Max(x => x.xValue) > second.points.Max(x => x.xValue) ? first.points.Max(x => x.xValue) : second.points.Max(x => x.xValue);
            int minX = first.points.Min(x => x.xValue) < second.points.Min(x => x.xValue) ? first.points.Min(x => x.xValue) : second.points.Min(x => x.xValue);
            int maxY = first.points.Max(y => y.yValue) > second.points.Max(y => y.xValue) ? first.points.Max(y => y.yValue) : second.points.Max(y => y.yValue);
            int minY = first.points.Min(y => y.yValue) < second.points.Min(y => y.xValue) ? first.points.Min(y => y.xValue) : second.points.Min(y => y.xValue);
            return new Rectangle(new Point(maxX, maxY), new Point(maxX, minY), new Point(minX, maxY), new Point(minX, minY));
        }

        /// <summary>
        /// Intersection of two rectangles
        /// </summary>
        /// <param name="first">One rectangle</param>
        /// <returns>new rectangle that consist of the intersection of the two other</returns>
        public Rectangle IntersectRectangle(Rectangle first)
        {
            Rectangle second = this;
            int[] xAxis = new int[]
            {   first.points.Max(x => x.xValue),
                first.points.Min(x => x.xValue),
                second.points.Max(x => x.xValue),
                second.points.Min(x => x.xValue)
            };
            int[] yAxis = new int[]
            {   first.points.Max(y => y.yValue),
                first.points.Min(y => y.yValue),
                second.points.Max(y => y.yValue),
                second.points.Min(y => y.yValue)
            };
            xAxis = changeArrayPositions(xAxis);
            yAxis = changeArrayPositions(yAxis);

            if ((xAxis[0] >= xAxis[2] && xAxis[1] <= xAxis[3]) && (yAxis[0] >= yAxis[2] && yAxis[1] <= yAxis[3]))
                return new Rectangle(new Point(xAxis[3], yAxis[3]), new Point(xAxis[3], yAxis[2]), new Point(xAxis[2], yAxis[2]), new Point(xAxis[2], yAxis[3]));
            return new Rectangle();
        }

        /// <summary>
        /// Verification of array positions
        /// </summary>
        /// <param name="arr">the array to change if needed</param>
        /// <returns>array (changed/unchanged)</returns>
        public int[] changeArrayPositions(int[] arr)
        {
            if (arr[2] > arr[0])
            {
                int temp = arr[2];
                arr[2] = arr[0];
                arr[0] = temp;
            }

            if (arr[3] < arr[1])
            {
                int temp = arr[3];
                arr[3] = arr[1];
                arr[1] = temp;
            }
            return arr;
        }

        /// <summary>
        /// Print of object data
        /// </summary>
        /// <param name="a">Retangle data to print</param>
        /// <returns>Printed value</returns>
        public static string Print(Rectangle a)
        {
            return $"a1({a.points[0].xValue};{a.points[0].yValue}) a2({a.points[1].xValue};{a.points[1].yValue}) a3({a.points[2].xValue};{a.points[2].yValue}) a4({a.points[3].xValue};{a.points[3].yValue})";
        }

        /// <summary>
        /// Rectangle movement
        /// </summary>
        /// <param name="x">X value of movement</param>
        /// <param name="y">Y value of movement</param>
        /// <returns>New rectangle</returns>
        public Rectangle Move(int x, int y)
        {
            Rectangle rectangle = new Rectangle(new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0));
            rectangle.points[0].xValue = points[0].xValue + x;
            rectangle.points[0].yValue = points[0].yValue + y;
            rectangle.points[1].xValue = points[1].xValue + x;
            rectangle.points[1].yValue = points[1].yValue + y;
            rectangle.points[2].xValue = points[2].xValue + x;
            rectangle.points[2].yValue = points[2].yValue + y;
            rectangle.points[3].xValue = points[3].xValue + x;
            rectangle.points[3].yValue = points[3].yValue + y;
            return rectangle;
        }
    }
}
