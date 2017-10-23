using System;

namespace _01.Persons
{
    class Persons
    {
        private string name;
        private int age;
        private string email;

        public string Name
        {
            get { return this.name; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age;  }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw  new ArgumentOutOfRangeException("Age must be in range 1-100");
                }
                this.age = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (!string.IsNullOrEmpty(value) && !IsValid(value))
                {
                    throw new ArgumentException("Email is not valid!");
                }
                this.email = value;
            }
        }

        private bool IsValid(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '@')
                {
                    return true;
                }
            }

            return false;
        }

        public Persons(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public Persons(string name, int age) : this(name, age, null) { }
      
        override public string ToString()
        {
            return $"Name: {this.Name}\nAge: {this.Age}\nEmail: {this.Email ?? "[not provided]"}\n";
        }

        static void Main()
        {
            Persons pesho = new Persons("Pesho", 24, "peshooo@abv.bg");
            Persons gosho = new Persons("Gosho", 19);

            Console.WriteLine(pesho);
            Console.WriteLine(gosho);
        }
    }
}