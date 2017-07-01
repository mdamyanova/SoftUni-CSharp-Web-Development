using System;

namespace _05.PizzaCalories.Models
{
    public class Topping
    {
        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string Type
        {
            get
            {
                return this.type;
            }

            set
            {
                if (!value.ToLowerInvariant().Equals("meat")
                    && !value.ToLowerInvariant().Equals("veggies")
                    && !value.ToLowerInvariant().Equals("cheese")
                    && !value.ToLowerInvariant().Equals("sauce"))
                {
                    throw new ArgumentException(string.Format("Cannot place {0} on top of your pizza.", value));
                }

                this.type = value;
            }
        }

        private int Weight
        {
            get
            {
                return this.weight;
            }

            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format("{0} weight should be in the range [1..50].", this.type));
                }

                this.weight = value;
            }
        }

        private double GetTypeMod()
        {
            switch (this.Type.ToLower())
            {
                case "meat":
                    return 1.2;
                case "veggies":
                    return 0.8;
                case "cheese":
                    return 1.1;
                case "sauce":
                    return 0.9;
                default:
                    return 1.0;
            }
        }

        public double GetTotalCalories() => (2 * this.Weight) * this.GetTypeMod();
    }
}