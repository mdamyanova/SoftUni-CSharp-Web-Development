using System;

namespace _05.PizzaCalories.Models
{
    public class Dough
    {
        private const int BaseCaloriesPerGram = 2;
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            set
            {
                if (!value.ToLowerInvariant().Equals("white")
                    && !value.ToLowerInvariant().Equals("wholegrain"))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (!value.ToLowerInvariant().Equals("crispy")
                    && !value.ToLowerInvariant().Equals("chewy")
                    && !value.ToLowerInvariant().Equals("homemade"))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        private double Weight
        {
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        private double GetBakingTechniqueMod()
        {
            switch (this.flourType.ToLower())
            {
                case "white":
                    return 1.5;
                case "wholegrain":
                    return 1.0;
                default:
                    return 1.0;
            }
        }

        private double GetFlourMod()
        {
            switch (this.bakingTechnique.ToLower())
            {
                case "crispy":
                    return 0.9;
                case "chewy":
                    return 1.1;
                case "homemade":
                    return 1.0;
                default:
                    return 1.0;
            }
        }

        public double GetTotalCalories() =>
            (2 * this.weight) * this.GetFlourMod() * this.GetBakingTechniqueMod();
    }
}