using System;
using System.Text;

public class Circle : Shape
{
    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public double Radius { get; set; }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * this.Radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * this.Radius * this.Radius;
    }

    public override string Draw()
    {
        return base.Draw() + "Circle";
    }
}