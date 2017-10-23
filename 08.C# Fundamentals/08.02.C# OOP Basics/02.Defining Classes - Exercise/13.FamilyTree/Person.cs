using System.Collections.Generic;

namespace _13.FamilyTree
{
    public class Person
    {
        public Person(string name, string birthDay)
        {
            this.Name = name;
            this.Birthday = birthDay;
            this.Parents = new List<Person>();
            this.Children = new List<Person>();
        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public List<Person> Parents { get; set; }

        public List<Person> Children { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }
}