using _07.FoodShortage.Interfaces;

namespace _07.FoodShortage.Models
{
    public class Buyer : IBuyer
    {
        public Buyer(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Food { get; set; }
        public int FoodCount { get; set; }

        public void BuyFood()
        {
            this.Food += this.FoodCount;
        }
    }
}