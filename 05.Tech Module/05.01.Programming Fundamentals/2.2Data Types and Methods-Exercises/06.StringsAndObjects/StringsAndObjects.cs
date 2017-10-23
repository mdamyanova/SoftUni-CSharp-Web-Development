using System;

namespace _06.StringsAndObjects
{
    public class StringsAndObjects
    {
        public static void Main()
        {
            string hello = "Hello";
            string world = "World";

            object concat = hello + " " + world;
            string result = (string) concat;

            Console.WriteLine(result);
        }
    }
}