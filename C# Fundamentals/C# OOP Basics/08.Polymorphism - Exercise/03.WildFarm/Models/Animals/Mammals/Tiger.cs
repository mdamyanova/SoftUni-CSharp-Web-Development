using System;

namespace _03.WildFarm.Models.Animals.Mammals
{
    public class Tiger : Felime
    {
        public Tiger(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }

        public override void Eat(Food food)
        {
            var type = food.GetType().Name;

            if (type != "Meat")
            {
                Console.WriteLine("Tigers are not eating that type of food!");
            }
            else
            {
                this.FoodEaten += food.Quantity;
            }
        }
    }
}