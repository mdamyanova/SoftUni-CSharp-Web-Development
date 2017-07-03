namespace _14.CatLady.Models
{
    public class Siamese : Cat
    {       
        public Siamese(string name, double earSize) : base(name)
        {
            this.EarSize = earSize;
        }

        public double EarSize { get; set; }

        public override string ToString()
        {
            return $"Siamese {this.Name} {this.EarSize}";
        }
    }
}