using System;

namespace _02.CircleArea
{
    public class CircleArea
    {
        public static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine($"{Math.PI*r*r:f12}");
        }
    }
}