using System;

namespace _15.DrawingTool.Models
{
    public class Square : CorDraw
    {
        public Square(int sizes)
        {
            this.Sizes = sizes;
        }

        public int Sizes { get; set; }

        public void Draw()
        {
            for (int i = 0; i < this.Sizes; i++)
            {
                if (i == 0 || i == this.Sizes - 1)
                {
                    Console.WriteLine($"|{new string('-', this.Sizes)}|");
                }
                else
                {
                    Console.WriteLine($"|{new string(' ', this.Sizes)}|");
                }
            }
        }
    }
}