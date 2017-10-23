using System;

namespace _06.Animals.Models
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get { return this.gender; }
            set
            {
                var temp = value.ToLowerInvariant();

                if (temp != "male" && temp != "female")
                    throw new ArgumentException("Invalid input!");

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "Not implemented!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}\n" +
                   $"{this.Name} {this.Age} {this.Gender}\n" +
                   $"{this.ProduceSound()}";
        }
    }
}