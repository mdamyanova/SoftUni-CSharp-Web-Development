using System;
using Geometry.Geometry3D;


namespace Geometry
{
    class Program
    {
        static void Main(string[] args)
        {

#region 01.Point3D
            var point = new Point3D(12.4, 2.6, 1);
            Console.WriteLine(Point3D.StartingPoint);
            Console.WriteLine(point);
            #endregion

#region 02.DistanceCalculator
            Point3D a = new Point3D(2.4, 13.7, 21);
            Point3D b = new Point3D(7.9, 21.4, 31);

            Console.WriteLine(DistanceCalculator.CalculateDistance(a, b));

            #endregion

#region 03.Paths
 
            Storage.Storage.LoadPaths();

            var points = new Path3D(
                new Point3D(2.3, 6.7, 13.75),
                new Point3D(75, 52.5, 13.8),
                new Point3D(8.93, 14.5, 6.1));
            
            Storage.Storage.SavePaths(points);

            #endregion

        }
    }
}