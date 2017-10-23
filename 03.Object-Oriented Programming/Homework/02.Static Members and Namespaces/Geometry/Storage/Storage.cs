using System.Collections.Generic;
using System.IO;
using Geometry.Geometry3D;

namespace Geometry.Storage
{
    public static class Storage
    {
        private static Point3D a;
        private static Point3D b;

        public static Point3D A { get; set; }
        public static Point3D B { get; set; }

        public static Path3D LoadPaths()
        {
            StreamReader reader = new StreamReader(@"../../points.txt");
            List<Point3D> points = new List<Point3D>();

            using (reader)
            {
                while (true)
                {                                  
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }
                    string[] args = line.Trim().Split('/');

                    string[] pointA = args[0].Split(new char[] {' '});
                    double Ax = double.Parse(pointA[0]);
                    double Ay = double.Parse(pointA[1]);
                    double Az = double.Parse(pointA[2]);

                    string[] pointB = args[1].Split(new char[] {' '});
                    double Bx = double.Parse(pointB[0]);
                    double By = double.Parse(pointB[1]);
                    double Bz = double.Parse(pointB[2]);

                    a = new Point3D(Ax, Ay, Az);
                    b = new Point3D(Bx, By, Bz);
                    
                    points.Add(a);
                    points.Add(b);
                }
            }
            return new Path3D(points.ToArray());
        }

        public static void SavePaths(Path3D points)
        {
            StreamWriter writer = new StreamWriter(@"../../SavePoints.txt");

            using (writer)
            {
                foreach (Point3D point in points.Points)
                {
                    writer.WriteLine("({0}, {1}, {2})", point.X, point.Y, point.Z);
                }
            }         
        }
    }
}