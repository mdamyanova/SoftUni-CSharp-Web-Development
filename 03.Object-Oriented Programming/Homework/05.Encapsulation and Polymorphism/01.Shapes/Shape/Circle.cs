using System;
using _01.Shapes.Interface;

namespace _01.Shapes.Shape
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public double CalculateArea()
        {
            return Math.Pow(this.Radius, 2)*Math.PI;            
        }

        public double CalculatePerimeter()
        {
            return 2*Math.PI*this.Radius;          
        }
    }
}