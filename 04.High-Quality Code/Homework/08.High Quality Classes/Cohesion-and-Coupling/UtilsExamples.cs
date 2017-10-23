namespace CohesionAndCoupling
{
    using System;

    using CohesionAndCoupling.Models;

    class UtilsExamples
    {
        static void Main()
        {
            //Console.WriteLine(FileExtension.GetFileExtension("example"));
            Console.WriteLine(FileExtension.GetFileExtension("example.pdf"));
            Console.WriteLine(FileExtension.GetFileExtension("example.new.pdf"));

            //Console.WriteLine(FileExtension.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileExtension.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileExtension.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                TwoDimensional.CalculateDistance(new TwoDimensional(1, 3, -2, 4)));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                ThreeDimensional.CalculateDistance(new ThreeDimensional(5, 3, 2, -6, -1, 4)));

            DimensionMethods.Width = 3;
            DimensionMethods.Height = 4;
            DimensionMethods.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", DimensionMethods.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", ThreeDimensional.CalculateDiagonal());
            Console.WriteLine("Diagonal XY = {0:f2}", TwoDimensional.CalculateDiagonalXy());
            Console.WriteLine("Diagonal XZ = {0:f2}", TwoDimensional.CalculateDiagonalXz());
            Console.WriteLine("Diagonal YZ = {0:f2}", TwoDimensional.CalculateDiagonalYz());
        }
    }
}