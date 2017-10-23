namespace _01.Shapes.Shape
{
    public class Rectangle : BasicShape
    {
        public override double CalculateArea()
        {
           return this.Height*this.Width;
        }

        public override double CalculatePerimeter()
        {
            return this.Height*2 + this.Width*2;
            
        }

        public Rectangle(double width, double height) : base(width, height)
        {
        }
    }
}