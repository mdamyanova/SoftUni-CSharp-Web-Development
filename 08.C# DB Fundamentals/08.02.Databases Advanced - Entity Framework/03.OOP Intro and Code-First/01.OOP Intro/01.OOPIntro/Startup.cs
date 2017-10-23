using System;
using _01.OOPIntro.Models;

namespace _01.OOPIntro
{
    class Startup
    {
        static void Main()
        {
            // 01. Define a class Person and create objects
            //Person pesho = new Person("Pesho", 20);
            //Person gosho = new Person("Gosho", 18);
            //Person stamat = new Person("Stamat", 43);

            //var input = Console.ReadLine();
            //Person person = new Person();

            //if (input != null)
            //{
            //    var tokens = input.Split(',');
            //    switch (tokens.Length)
            //    {
            //        case 1:
            //            int age;
            //            person = int.TryParse(tokens[0], out age) ? new Person(age) : new Person(tokens[0]);
            //            break;
            //        case 2:
            //            person = new Person(tokens[0], int.Parse(tokens[1]));
            //            break;
            //    }
            //}

            //Console.WriteLine(person);

            // 03. Oldest family member
            //int count = int.Parse(Console.ReadLine());
            //Family family = new Family();
            //for (int i = 0; i < count; i++)
            //{
            //    var currArgs = Console.ReadLine().Split();
            //    Person currPerson = new Person(currArgs[0], int.Parse(currArgs[1]));
            //    family.AddMember(currPerson);
            //}
            //Console.WriteLine(family.GetOldestMember());

            // 04. Students
            //string name = Console.ReadLine();
            //while (name != "End")
            //{
            //    var student = new Student(name);
            //    name = Console.ReadLine();
            //}
            //Console.WriteLine(Student.Count);

            // 05. Planck constant
            //Console.WriteLine(Calculation.GetPlanckConstant());

            // 06. Math utilities
            string command = Console.ReadLine();
            while (command != "End")
            {
                var tokens = command.Split();
                double first = double.Parse(tokens[1]);
                double second = double.Parse(tokens[2]);

                double result = 0;
                switch (tokens[0])
                {
                    case "Sum":
                        result = MathUtil.Sum(first, second);
                        break;
                    case "Subtract":
                        result = MathUtil.Subtract(first, second);
                        break;
                    case "Multiply":
                        result = MathUtil.Multiply(first, second);
                        break;
                    case "Divide":
                        result = MathUtil.Divide(first, second);
                        break;
                    case "Percentage":
                        result = MathUtil.Percentage(first, second);
                        break;
                }

                Console.WriteLine($"{result:f2}");
                command = Console.ReadLine();
            }
        }
    }
}