using System.Text;

namespace NeedForSpeed.Models.Cars
{
    public class ShowCar : Car
    {
        //private int stars;

        public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) : 
            base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
        {
            this.Stars = 0;
        }

        public int Stars { get; protected set; }

        public override void TuneUp(int tuneIndex, string addOn)
        {
            var increaseHorsepower = tuneIndex;
            var increaseSuspension = (int)(tuneIndex / 2);

            this.Horsepower += increaseHorsepower;
            this.Suspension += increaseSuspension;
            this.Stars += tuneIndex;
        }


        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"{this.Stars} *");

            return sb.ToString().Trim();
        }
    }
}