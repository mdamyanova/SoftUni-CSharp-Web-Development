
namespace Geometry.Geometry3D
{
    public class Point3D
    {
        private static readonly Point3D StartPoint;
        private double x;
        private double y;
        private double z;

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public static Point3D StartingPoint
        {
            get { return StartPoint; }
        }

        static Point3D()
        {
            StartPoint = new Point3D(0, 0, 0);
        }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return $"x = {this.X}\ny = {this.Y}\nz = {this.Z}\n";
        }
    }
}