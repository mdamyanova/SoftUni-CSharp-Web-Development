using System;
using _15.DrawingTool.Models;

namespace _15.DrawingTool
{
    public class Program
    {
        public static void Main()
        {
            var figure = Console.ReadLine();

            switch (figure)
            {
                case "Square":
                    var sizes = int.Parse(Console.ReadLine());
                    var square = new Square(sizes);
                    square.Draw();
                    break;
                case "Rectangle":
                    var width = int.Parse(Console.ReadLine());
                    var height = int.Parse(Console.ReadLine());
                    var rectangle = new Rectangle(width, height);
                    rectangle.Draw();
                    break;
            }
        }
    }
}