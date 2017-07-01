namespace _01.ClassBox
{
    public class Box
    {    
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double SurfaceArea()
        {
            var surface = 2 * this.Length * this.Width + 
                2 * this.Length * this.Height + 
                2 * this.Width * this.Height;

            return surface;
        }

        public double LateralArea()
        {
            var lateralArea = 2 * this.Length * this.Height + 
                2 * this.Width * this.Height;

            return lateralArea;
        }

        public double Volume()
        {
            var volume = this.Length * this.Width * this.Height;

            return volume;
        }
    }
}