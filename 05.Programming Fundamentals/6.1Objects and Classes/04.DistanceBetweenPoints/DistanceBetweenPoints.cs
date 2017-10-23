using System;
using System.Linq;

namespace _04.DistanceBetweenPoints
{
    public class DistanceBetweenPoints
    {
        public static void Main()
        {
            var p1 = Point.ReadPoint();
            var p2 = Point.ReadPoint();
            Console.WriteLine("{0:f3}", Point.CalcDistance(p1, p2));
        }       
    }
}

public class Point
{
    public double X { get; set; }

    public double Y { get; set; }

    public static double CalcDistance(Point p1, Point p2)
    {
        var a = p1.X - p2.X;
        var b = p1.Y - p2.Y;
        var sum2 = a * a + b * b;
        var distance = Math.Sqrt(sum2);

        return distance;
    }

    public static Point ReadPoint()
    {
        var coords = Console.ReadLine().Split().Select(double.Parse).ToArray();
        var p = new Point() { X = coords[0], Y = coords[1] };

        return p;
    }
}