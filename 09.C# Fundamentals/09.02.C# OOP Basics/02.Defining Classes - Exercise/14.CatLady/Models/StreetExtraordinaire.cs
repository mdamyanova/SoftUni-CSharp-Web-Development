namespace _14.CatLady.Models
{
    public class StreetExtraordinaire : Cat
    {
        public StreetExtraordinaire(string name, double decibelsOfMeows) : base(name)
        {
            this.DecibelsOfMeows = decibelsOfMeows;
        }

        public double DecibelsOfMeows { get; set; }

        public override string ToString()
        {
            return $"StreetExtraordinaire {this.Name} {this.DecibelsOfMeows}";
        }
    }
}