using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var lines = int.Parse(Console.ReadLine());
        var people = new List<Person>();

        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            var person = new Person(cmdArgs[0],
                cmdArgs[1],
                int.Parse(cmdArgs[2]),
                double.Parse(cmdArgs[3]));

            people.Add(person);
        }

        var bonus = double.Parse(Console.ReadLine());
        people.ForEach(p => Console.WriteLine(p.ToString()));

    }
}