using _01.Shapes.Interface;

namespace _01.Shapes.Shape
{
    public abstract class BasicShape : IShape
    {
        public double Width { get; set; }
        
        public double Height { get; set; }

        protected BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();
    }
}