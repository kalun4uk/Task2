using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task12
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle a = new Rectangle(new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0));
            Rectangle b = new Rectangle(new Point(1, 0), new Point(1, 2), new Point(2, 2), new Point(2, 0));
            Console.WriteLine($"Paralelism = {a.checkBasicsParallelism()}");
            Console.WriteLine($"Paralelism = {b.checkBasicsParallelism()}");
            Console.WriteLine($"Size in two = {Rectangle.Print(a*2)}");
            Console.WriteLine($"Intersection = {Rectangle.Print(a.IntersectRectangle(b))}");
            Console.WriteLine($"NewTwoGetRectangles = {Rectangle.Print(a.NewTwoGetRect(b))}");
            Console.WriteLine($"MoveRectangle = {Rectangle.Print(a.Move(5,6))}");

            Console.ReadKey();
        }
    }
}
