using System;
using System.Collections.Generic;
using _01.Shapes.Interface;
using _01.Shapes.Shape;

namespace _01.Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
           List<IShape> shapes = new List<IShape>();
            shapes.Add(new Circle(5));
            shapes.Add(new Rectangle(2,6));
            shapes.Add(new Rhombus(6,6));

            foreach (var shape in shapes)
            {
                Console.WriteLine("Shape name: {0}\nArea: {1:f2}\nPerimeter: {2:f2}\n", 
                    shape.GetType().Name, shape.CalculateArea(), shape.CalculatePerimeter());
            }
        }
    }
}