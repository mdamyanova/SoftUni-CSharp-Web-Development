using System.ComponentModel.Design.Serialization;
using System.Security.AccessControl;

namespace _02.Animals
{
    public class Kitten : Cat
    {
        private const string Gender = "female";

        public Kitten(string name, int age) : base(name, age, Gender)
        {
            
        }
    }
}