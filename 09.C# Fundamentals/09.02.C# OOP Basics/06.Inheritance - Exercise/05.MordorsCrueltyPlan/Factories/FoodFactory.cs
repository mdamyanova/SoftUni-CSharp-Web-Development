using _05.MordorsCrueltyPlan.Models;
using _05.MordorsCrueltyPlan.Models.Foods;

namespace _05.MordorsCrueltyPlan.Factories
{
    public class FoodFactory
    {
        public static Food ProduceFood(string food)
        {
            switch (food.ToLower())
            {
                case "lembas":
                    return new Lembas();
                case "cram":
                    return new Cram();
                case "apple":
                    return new Apple();
                case "melon":
                    return new Melon();
                case "honeycake":
                    return new HoneyCake();
                case "mushrooms":
                    return new Mushrooms();
                default:
                    return new Unknown();
            }
        }
    }
}