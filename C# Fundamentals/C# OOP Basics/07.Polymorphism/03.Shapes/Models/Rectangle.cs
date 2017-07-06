using System.Text;

public class Rectangle : Shape
{
    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public double Height { get; set; }

    public double Width { get; set; }

    public override double CalculatePerimeter()
    {
        return this.Height * 2 + this.Width * 2;
    }

    public override double CalculateArea()
    {
        return this.Height * this.Width;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}



