using System;

public class Program
{
    public static void Main()
    {
        var spy = new Spy();
        var result = spy.RevealPrivateMethods("Hacker");
        Console.WriteLine(result);
    }
}