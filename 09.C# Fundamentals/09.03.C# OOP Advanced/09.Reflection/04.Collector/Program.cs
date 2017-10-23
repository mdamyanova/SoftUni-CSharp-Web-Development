using System;

public class Program
{
    public static void Main()
    {
        var spy = new Spy();
        var result = spy.CollectGettersAndSetters("Hacker");
        Console.WriteLine(result);
    }
}