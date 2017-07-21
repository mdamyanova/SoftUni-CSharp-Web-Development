using _05.BorderControl;
using _06.BirthdayCelebrations.Interfaces;

namespace _06.BirthdayCelebrations.Models
{
    public class Citizen : IIdentifiable, INameable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
    }
}