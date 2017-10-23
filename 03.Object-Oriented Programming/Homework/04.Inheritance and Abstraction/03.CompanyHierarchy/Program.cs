using System;
using System.Collections.Generic;
using _03.CompanyHierarchy.Emoployee;

namespace _03.CompanyHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer dev = new Developer(1367, "Boris", "Soltariiski", 1000, "Production", new List<Project>
            {
                new Project("Project", DateTime.Today, "My project"),
                new Project("Just another project", DateTime.Parse("4.04.2009"), "Nothing to write")
            });
           
            Manager man = new Manager(45625, "Gosho", "Peshev", 1500.2m, "Sales", new List<Employee>
            {
                new Employee(67356, "Mariika", "Ivanova", 356, "Accounting"),
                new Employee(63462, "Abdul", "Mahir", 782.4m, "Marketing")
            });

            SalesEmployee salesEmpl = new SalesEmployee(777353, "Dragan", "Koevich", 693.90m, "Sales", new List<Sale>
            {
                new Sale("Product", DateTime.Today, 100.90m)
            });

            List<Employee> employees = new List<Employee> {dev, man, salesEmpl};

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
