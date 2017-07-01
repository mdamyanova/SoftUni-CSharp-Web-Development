using System;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        var personType = typeof(Person);
        var fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine(fields.Length);
    }
}