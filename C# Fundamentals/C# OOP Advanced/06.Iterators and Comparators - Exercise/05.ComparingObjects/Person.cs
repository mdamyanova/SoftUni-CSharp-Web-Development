using System;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name.Equals(other.Name) && this.Age.Equals(other.Age) && this.Town.Equals(other.Town))
            {
                return 0;
            }
                return 1;           
        }
    }
}