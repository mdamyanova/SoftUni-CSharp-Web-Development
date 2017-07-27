using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        var type = typeof(Program);
        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        foreach (var methodInfo in methods)
        {
            if (methodInfo.CustomAttributes.Any(n => n.AttributeType == typeof(SoftUniAttribute)))
            {
                var attrs = methodInfo.GetCustomAttributes(false);
                foreach (SoftUniAttribute attr in attrs)
                {
                    Console.WriteLine($"{methodInfo.Name} is written by {attr.Name}");
                }
            }
        }
    }
}