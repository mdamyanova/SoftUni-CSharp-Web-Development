using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
            this.Parents = new List<Parent>();
            this.Children = new List<Children>();
            this.Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public Company Company { get; set; }
        public Car Car { get; set; }
        public List<Parent> Parents { get; set; }
        public List<Children> Children { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"{this.Name}\nCompany:\n");

            if (this.Company != null)
            {
                sb.AppendLine($"{this.Company.Name} {this.Company.Department} {this.Company.Salary:f2}");
            }

            sb.AppendLine("Car:");

            if (this.Car != null)
            {
                sb.AppendLine($"{this.Car.Model} {this.Car.Speed}");
            }

            sb.AppendLine("Pokemon:");

            foreach (var pokemon in this.Pokemons)
            {
                sb.AppendLine($"{pokemon.Name} {pokemon.Type}");
            }

            sb.AppendLine("Parents:");

            foreach (var parent in this.Parents)
            {
                sb.AppendLine($"{parent.Name} {parent.Birthday}");
            }

            sb.AppendLine("Children:");

            foreach (var children in this.Children)
            {
                sb.AppendLine($"{children.Name} {children.Birthday}");
            }
         
            return sb.ToString();
        }
    }
}