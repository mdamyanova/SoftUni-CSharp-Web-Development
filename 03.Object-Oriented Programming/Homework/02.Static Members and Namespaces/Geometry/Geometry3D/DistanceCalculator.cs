using System;

namespace Geometry.Geometry3D
{
     static class DistanceCalculator
    {
        private static Point3D a;
        private static Point3D b;

        public static Point3D A { get; set; }
        public static Point3D B { get; set; }

        public static double CalculateDistance(Point3D a, Point3D b)
        {
            double distance = 0;
            double tempCalc = Math.Pow((b.X - a.X), 2) + Math.Pow((b.Y - a.Y), 2) + Math.Pow((b.Z - a.Z), 2);
            distance = Math.Sqrt(tempCalc);
            return distance;
        }
    }
}