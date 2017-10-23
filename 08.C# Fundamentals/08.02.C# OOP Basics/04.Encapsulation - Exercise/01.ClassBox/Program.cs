using System;
using System.Linq;
using System.Reflection;

namespace _01.ClassBox
{
    public class Program
    {
        public static void Main()
        {
            var boxType = typeof(Box);
            var fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var box = new Box(length, width, height);

            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}\nLateral Surface Area - {box.LateralArea():f2}\nVolume - {box.Volume():f2}");
        }
    }
}