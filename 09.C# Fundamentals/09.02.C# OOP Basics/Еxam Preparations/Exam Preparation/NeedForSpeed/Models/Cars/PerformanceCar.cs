using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeedForSpeed.Models.Cars
{
    public class PerformanceCar : Car
    {
        //private List<string> addOns;

        public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) : 
            base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
        {
            this.AddOns = new List<string>();
            this.Horsepower += (this.Horsepower * 50) / 100;
            this.Suspension -= (this.Suspension * 25) / 100;
        }

        public List<string> AddOns { get; protected set; }

        public override void TuneUp(int tuneIndex, string addOn)
        {
            var increaseHorsepower = tuneIndex;
            var increaseSuspension = (int)(tuneIndex / 2);

            this.Horsepower += increaseHorsepower;
            this.Suspension += increaseSuspension;
            this.AddOns.Add(addOn);
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Add-ons: {(this.AddOns.Any() ? $"{string.Join(", ", this.AddOns)}" : "None")}");

            return sb.ToString().Trim();
        }
    }
}