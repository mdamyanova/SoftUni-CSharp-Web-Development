namespace _03.WildFarm.Models
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public abstract void MakeSound();

        public abstract void Eat(Food food);
    }
}