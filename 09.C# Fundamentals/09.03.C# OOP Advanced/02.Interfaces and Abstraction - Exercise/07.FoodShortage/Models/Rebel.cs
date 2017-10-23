namespace _07.FoodShortage.Models
{
    public class Rebel : Buyer
    {
        public Rebel(string name, int age, string group) : base(name, age)
        {
            this.FoodCount = 5;
            this.Group = group;
        }

        public string Group { get; set; }
    }
}