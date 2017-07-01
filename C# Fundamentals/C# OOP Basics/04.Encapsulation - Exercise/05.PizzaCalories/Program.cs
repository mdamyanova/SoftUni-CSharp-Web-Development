using System;
using _05.PizzaCalories.Models;

namespace _05.PizzaCalories
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                string inputLine;
                while ((inputLine = Console.ReadLine()) != "END")
                {
                    var tokens = inputLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    var command = tokens[0];
                    switch (command)
                    {
                        case "Pizza":
                            var pizza = MakePizza(tokens[1], int.Parse(tokens[2]));
                            Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():f2} Calories.");
                            break;
                        case "Dough":
                            var dough = new Dough(tokens[1], tokens[2], double.Parse(tokens[3]));
                            Console.WriteLine($"{dough.GetTotalCalories():f2}");
                            break;
                        case "Topping":
                            var topping = new Topping(tokens[1], int.Parse(tokens[2]));
                            Console.WriteLine($"{topping.GetTotalCalories():f2}");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static Pizza MakePizza(string name, int numberOfToppings)
        {
            var pizza = new Pizza(name, numberOfToppings);

            var doughInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            pizza.Dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));

            for (int i = 0; i < numberOfToppings; i++)
            {
                var toppingInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var topping = new Topping(toppingInfo[1], int.Parse(toppingInfo[2]));
                pizza.AddTopping(topping);
            }

            return pizza;
        }
    }
}