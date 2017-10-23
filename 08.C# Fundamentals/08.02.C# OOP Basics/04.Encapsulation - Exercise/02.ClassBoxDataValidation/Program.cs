using System;
using System.Linq;
using System.Reflection;
using _01.ClassBox;

namespace _02.ClassBoxDataValidation
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

            try
            {
                var box = new Box(length, width, height);

                Console.WriteLine(
                    $"Surface Area - {box.SurfaceArea():f2}\nLateral Surface Area - {box.LateralArea():f2}\nVolume - {box.Volume():f2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }         
        }
    }
}