using System.Text;

namespace NeedForSpeed.Models
{
    public abstract class Car
    {
        //private string brand;
        //private string model;
        //private int yearOfProduction;
        //private int horsepower;
        //private int acceleration;
        //private int suspension;
        //private int durability;
        //private int carPoints;

        protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension,
            int durability)
        {
            this.Brand = brand;
            this.Model = model;
            this.YearOfProduction = yearOfProduction;
            this.Horsepower = horsepower;
            this.Acceleration = acceleration;
            this.Suspension = suspension;
            this.Durability = durability;
        }

        public string Brand { get; protected set; }
        public string Model { get; protected set; }
        public int YearOfProduction { get; private set; }
        public int Horsepower { get; set; }
        public int Acceleration { get; protected set; }
        public int Suspension { get; set; }
        public int Durability { get; protected set; }
        public int CarPoints { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
            sb.AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s");
            sb.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

            return sb.ToString();
        }

        public abstract void TuneUp(int tuneIndex, string addOn);
    }
}