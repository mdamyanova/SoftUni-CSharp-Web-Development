namespace CohesionAndCoupling.Models
{
    using System;

    public class ThreeDimensional : DimensionMethods
    {
        private double z1;

        private double z2;

        public ThreeDimensional(double x1, double x2, double y1, double y2, double z1, double z2)
            : base(x1, x2, y1, y2)
        {
            Z1 = z1;
            Z2 = z2;
        }

        public ThreeDimensional(
            double x1,
            double x2,
            double y1,
            double y2,
            double width,
            double height,
            double depth,
            double z1,
            double z2)
            : base(x1, x2, y1, y2, width, height, depth)
        {
            Z1 = z1;
            Z2 = z2;
        }

        public static double Z1 { get; set; }

        public static double Z2 { get; set; }

        public static double CalculateDistance(DimensionMethods point)
        {
            double distance = Math.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1) + (Z2 - Z1) * (Z2 - Z1));

            ValidateDistance(distance);

            return distance;
        }

        public static double CalculateDiagonal()
        {
            double distance = CalculateDistance(new ThreeDimensional(0, Width, 0, Height, 0, Depth));
            ValidateDistance(distance);

            return distance;
        }
    }
}