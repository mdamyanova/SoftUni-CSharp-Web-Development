using System;

namespace _15.DrawingTool.Models
{
    public class Rectangle : CorDraw
    {
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public void Draw()
        {
            for (int i = 0; i < this.Height; i++)
            {
                if (i == 0 || i == this.Height - 1)
                {
                    Console.WriteLine($"|{new string('-', this.Width)}|");
                }
                else
                {
                    Console.WriteLine($"|{new string(' ', this.Width)}|");
                }
            }
        }
    }
}