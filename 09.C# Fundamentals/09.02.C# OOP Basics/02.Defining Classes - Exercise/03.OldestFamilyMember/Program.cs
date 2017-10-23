using System;

public class Program
{
    public static void Main()
    {
        var oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        var addMemberMethod = typeof(Family).GetMethod("AddMember");

        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        var family = new Family();
        
        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            family.AddMember(new Person(input[0], int.Parse(input[1])));
        }

        var oldestMember = family.GetOldestMember();
        Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
    }
}