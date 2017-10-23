namespace _09.RectangleIntersection
{
    public class Rectangle
    {
        private double width;
        private double height;
        private double topLeftX;
        private double topLeftY;

        public string ID { get; set; }

        public Rectangle(string id, double width, double height, double topLeftX, double topLeftY)
        {
            this.ID = id;
            this.width = width;
            this.height = height;
            this.topLeftX = topLeftX;
            this.topLeftY = topLeftY;
        }

        public bool DoIntersectWith(Rectangle r2)
        {
            if (this.topLeftX > r2.topLeftX + r2.width || r2.topLeftX > this.topLeftX + width)
            {
                return false;
            }

            if (this.topLeftY < r2.topLeftY - height || r2.topLeftY < this.topLeftY - height)
            {
                return false;
            }
            return true;
        }
    }
}