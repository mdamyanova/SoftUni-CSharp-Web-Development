namespace _07.FoodShortage.Models
{
    public class Citizen : Buyer
    {
        public Citizen(string name, int age, string id, string birthdate) : base(name, age)
        {
            this.FoodCount = 10;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Id { get; set; }
        public string Birthdate { get; set; }
    }
}