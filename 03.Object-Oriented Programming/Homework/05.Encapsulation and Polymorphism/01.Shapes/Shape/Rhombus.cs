namespace _01.Shapes.Shape
{
    public class Rhombus : BasicShape
    {
        public override double CalculateArea()
        {
            return this.Width*this.Height;
        }

        public override double CalculatePerimeter()
        {
            return 4*this.Width;
        }

        public Rhombus(double width, double height) : base(width, height)
        {
        }
    }
}