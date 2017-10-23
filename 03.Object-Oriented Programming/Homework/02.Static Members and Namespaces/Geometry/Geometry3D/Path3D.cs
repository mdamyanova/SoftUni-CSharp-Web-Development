using System.Collections.Generic;

namespace Geometry.Geometry3D
{
    public class Path3D
    {
        private List<Point3D> points;

        public List<Point3D> Points { get { return points; } }

        public Path3D(params Point3D[] args)
        {
            this.points = new List<Point3D>();
            this.AddPoints(args);
        }

        private void AddPoints(params Point3D[] args)
        {
            this.points.AddRange(args);
        }
    }
}