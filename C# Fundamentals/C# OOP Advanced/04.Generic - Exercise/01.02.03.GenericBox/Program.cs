using System;

namespace _01._02._03.GenericBox
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var box = new Box<int>(int.Parse(input));
                Console.WriteLine(box.ToString());
            }           
        }
    }
}