namespace CohesionAndCoupling.Models
{
    using System;

    public class TwoDimensional : DimensionMethods
    {
        public TwoDimensional(double x1, double x2, double y1, double y2)
            : base(x1, x2, y1, y2)
        {
        }

        public TwoDimensional(double x1, double x2, double y1, double y2, double width, double height, double depth)
            : base(x1, x2, y1, y2, width, height, depth)
        {
        }

        public static double CalculateDistance(DimensionMethods point)
        {
            double distance = Math.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1));

            ValidateDistance(distance);

            return distance;
        }

        public static double CalculateDiagonalXy()
        {
            double distance = CalculateDistance(new TwoDimensional(0, Width, 0, Height));
            ValidateDistance(distance);

            return distance;
        }

        public static double CalculateDiagonalXz()
        {
            double distance = CalculateDistance(new TwoDimensional(0, Width, 0, Depth));
            ValidateDistance(distance);

            return distance;
        }

        public static double CalculateDiagonalYz()
        {
            double distance = CalculateDistance(new TwoDimensional(0, Height, 0, Depth));
            ValidateDistance(distance);

            return distance;
        }
    }
}