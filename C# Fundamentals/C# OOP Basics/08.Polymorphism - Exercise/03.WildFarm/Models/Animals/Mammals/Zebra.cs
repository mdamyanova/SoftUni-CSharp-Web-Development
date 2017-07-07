using System;

namespace _03.WildFarm.Models.Animals.Mammals
{
    public class Zebra : Mammal
    {
        public Zebra(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Zs");
        }

        public override void Eat(Food food)
        {
            var type = food.GetType().Name;

            if (type != "Vegetable")
            {
                Console.WriteLine("Zebras are not eating that type of food!");
            }
            else
            {
                this.FoodEaten += food.Quantity;
            }
        }       
    }
}