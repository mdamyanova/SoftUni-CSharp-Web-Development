namespace _06.Animals.Models
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender) : base(name, age, "Male")
        {
        }

        public override string ProduceSound()
        {
            return "Give me one million b***h";
        }
    }
}