namespace _06.Animals.Models
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender) : base(name, age, "Female")
        {
        }

        public override string ProduceSound()
        {
            return "Miau";
        }
    }
}