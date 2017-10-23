using System;
using _05.MordorsCrueltyPlan.Factories;
using _05.MordorsCrueltyPlan.Models;

namespace _05.MordorsCrueltyPlan
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var gandalf = new Gandalf();

            foreach (var str in input)
            {
                var food = FoodFactory.ProduceFood(str);
                gandalf.Eat(food);
            }

            Console.WriteLine(gandalf);
        }
    }
}
