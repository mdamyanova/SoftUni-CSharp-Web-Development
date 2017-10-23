using System;
using System.Linq;

namespace _03.IntersectionOfCircles
{
    public class IntersectionOfCircles
    {
        public static void Main()
        {
            var c1 = Circle.ReadCircle();
            var c2 = Circle.ReadCircle();

            Console.WriteLine(Circle.Intersect(c1, c2) ? "Yes" : "No");
        }
    }
}

public class Circle
{
    public Point Center { get; set; }

    public double Radius { get; set; }

    public static Circle ReadCircle()
    {
        double[] args = Console.ReadLine().Split().Select(double.Parse).ToArray();

        var circle = new Circle
                         {
                             Center = new Point() { X = args[0], Y = args[1] },
                             Radius = args[2]
                         };

        return circle;
    }

    public static bool Intersect(Circle c1, Circle c2)
    {
        double x = Math.Pow(c2.Center.X - c1.Center.X, 2);
        double y = Math.Pow(c2.Center.Y - c1.Center.Y, 2);
        double distance = Math.Sqrt(x + y);

        if (distance <= c1.Radius + c2.Radius)
        {
            return true;
        }

        return false;
    }
}

public class Point
{
    public double X { get; set; }

    public double Y { get; set; }
}