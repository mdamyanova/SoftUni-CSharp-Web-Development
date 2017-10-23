using System;

public class Program
{
    public static void Main()
    {
        var box = new Box<int>();
        box.Add(1);
        box.Add(2);
        box.Add(3);

        Console.WriteLine(box.Remove());

        box.Add(4);
        box.Add(5);

        Console.WriteLine(box.Remove());
    }
}