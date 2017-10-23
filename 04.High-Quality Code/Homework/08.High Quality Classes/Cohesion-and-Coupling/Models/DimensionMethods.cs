namespace CohesionAndCoupling.Models
{
    using System;

    public abstract class DimensionMethods
    {
        private double x1;

        private double x2;

        private double y1;

        private double y2;

        protected DimensionMethods(double x1, double x2, double y1, double y2)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }

        protected DimensionMethods(
            double x1,
            double x2,
            double y1,
            double y2,
            double width,
            double height,
            double depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        public static double X1 { get; set; }

        public static double X2 { get; set; }

        public static double Y1 { get; set; }

        public static double Y2 { get; set; }

        public static double Width { get; set; }

        public static double Height { get; set; }

        public static double Depth { get; set; }

        public static double CalculateVolume()
        {
            double volume = Width * Height * Depth;

            return volume;
        }

        protected static void ValidateDistance(double distance)
        {
            if (distance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(distance), "Distance cannot be negative");
            }
        }
    }
}