using System;
using System.Linq;

namespace _05.ClosestTwoPoints
{
    public class ClosestTwoPoints
    {
        public static void Main()
        {
            var points = Point.ReadArrayOfPoints();

            var nearestPoints = FindNearestPoints(points);
            Console.WriteLine($"{Point.CalcDistance(nearestPoints[0], nearestPoints[1]):f3}");
            Console.WriteLine(nearestPoints[0]);
            Console.WriteLine(nearestPoints[1]);
        }

        public static Point[] FindNearestPoints(Point[] points)
        {
            var minDistance = double.MaxValue;
            Point[] nearestPoints = null;
           
            for (int first = 0; first < points.Length; first++)
            {
                for (int second = first + 1; second < points.Length; second++)
                {
                    var p1 = points[first];
                    var p2 = points[second];
                    var dist = Point.CalcDistance(p1, p2);
                    if (dist < minDistance)
                    {
                        minDistance = dist;
                        nearestPoints = new Point[] {p1, p2};
                    }
                }
            }

            return nearestPoints;
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

    public static Point[] ReadArrayOfPoints()
    {
        var n = int.Parse(Console.ReadLine());
        var points = new Point[n];

        for (int i = 0; i < n; i++)
        {
            points[i] = Point.ReadPoint();
        }

        return points;
    }

    public override string ToString()
    {
        return $"({this.X}, {this.Y})";
    }
}