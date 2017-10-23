namespace _02.Animals
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
    }
}