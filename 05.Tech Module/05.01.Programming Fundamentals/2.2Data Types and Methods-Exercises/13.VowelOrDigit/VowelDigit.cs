using System;

namespace _13.VowelOrDigit
{
    public class VowelDigit
    {
        public static void Main()
        {
            char input = char.Parse(Console.ReadLine());

            if (Char.IsDigit(input))
            {
                Console.WriteLine("digit");
            }
            else if (input == 'a' || input == 'e'
                || input == 'i' || input == 'o' || input == 'u')
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}