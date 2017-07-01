using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.RectangleIntersection
{
    public class Program
    {
        public static void Main()
        {
            var args = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rectanglesCount = args[0];
            var checksCount = args[1];
            var rectangles = new List<Rectangle>();

            for (int i = 0; i < rectanglesCount; i++)
            {
                var input = Console.ReadLine().Split();
                var currentRectangle = new Rectangle(input[0], double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]), double.Parse(input[4]));
                rectangles.Add(currentRectangle);
            }

            for (int i = 0; i < checksCount; i++)
            {
                var input = Console.ReadLine().Split();
                var r1 = rectangles.FirstOrDefault(r => r.ID.Equals(input[0]));
                var r2 = rectangles.FirstOrDefault(r => r.ID.Equals(input[1]));
                Console.WriteLine(r1.DoIntersectWith(r2).ToString().ToLower());
            }
        }
    }
}