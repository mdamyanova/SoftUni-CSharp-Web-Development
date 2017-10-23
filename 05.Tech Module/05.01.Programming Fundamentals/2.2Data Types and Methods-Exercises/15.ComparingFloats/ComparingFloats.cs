using System;

namespace _15.ComparingFloats
{
    public class ComparingFloats
    {
        public static void Main()
        {
            const double Eps = 0.000001;
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            bool areEqual = Math.Abs(a - b) < Eps;

            Console.WriteLine(areEqual);
        }
    }
}