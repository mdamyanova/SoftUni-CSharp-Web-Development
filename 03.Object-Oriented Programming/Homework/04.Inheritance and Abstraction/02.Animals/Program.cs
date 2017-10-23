using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02.Animals
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Animal[] animals = new Animal[10];
            animals[0] = new Frog("Gosho", 3, "male");
            animals[1] = new Kitten("Kitty", 5);
            animals[2] = new Dog("Rex", 12, "male");
            animals[3] = new Tomcat("Tom", 1);
            animals[4] = new Kitten("Bety", 6);
            animals[5] = new Frog("Frogy", 1, "female");
            animals[6] = new Tomcat("Pesho", 7);
            animals[7] = new Dog("Sarah", 4, "female");
            animals[8] = new Kitten("Katy", 1);
            animals[9] = new Frog("Kwiky", 3, "female");

            animals.GroupBy(a => a.GetType().Name)
                .Select(group => new
                {
                   AnimalName = group.Key,
                   AverageAge = group.Average(a => a.Age)  
                })
                .OrderByDescending(group => group.AverageAge)
                .ToList()
                .ForEach(group => Console.WriteLine($"{group.AnimalName}'s average age is: {group.AverageAge}"));
        }
    }
}
