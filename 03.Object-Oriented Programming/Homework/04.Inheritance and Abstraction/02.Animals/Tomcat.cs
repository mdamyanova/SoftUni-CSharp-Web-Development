namespace _02.Animals
{
    public class Tomcat : Cat
    {
        private const string Gender = "male";

        public Tomcat(string name, int age) : base(name, age, Gender)
        {
        }
    }
}