namespace Operations
{
    using System;

    public class CalculateAverage
    {
        public static void CalcAverage()
        {
            Console.Write("A = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("B = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("C = ");
            double c = double.Parse(Console.ReadLine());
            Console.Write("Average sum is: {0:f7}", (a + b + c) / 3);
            Console.WriteLine();

        }
    }
}