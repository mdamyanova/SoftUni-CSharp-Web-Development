using System;
using System.Collections.Generic;

namespace _05.PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private int numberOfToppings;
        private List<Topping> toppings;

        public Pizza(string name, int numberOfToppings)
        {
            this.Name = name;
            this.NumberOfToppings = numberOfToppings;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public int NumberOfToppings
        {
            get
            {
                return this.numberOfToppings;
            }

            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }

                this.numberOfToppings = value;
            }
        }

        public Dough Dough
        {
            set
            {
                this.dough = value ?? throw new ArgumentException("Dough cannot be null.");
            }
        }

        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
        }

        public double GetTotalCalories()
        {
            var totalCalories = 0.0;
            foreach (var topping in this.toppings)
            {
                totalCalories += topping.GetTotalCalories();
            }

            totalCalories += this.dough.GetTotalCalories();

            return totalCalories;
        }
    }
}