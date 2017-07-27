using System;
using _06.CustomEnumAttribute.Enums;

namespace _06.CustomEnumAttribute
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            Type type = null;

            switch (input)
            {
                case "Rank":
                    type = typeof(CardRank);
                    break;
                case "Suit":
                    type = typeof(CardSuit);
                    break;
            }

            var attributes = type.GetCustomAttributes(false);
            foreach (TypeAttribute attribute in attributes)
            {
                Console.WriteLine("Type = {0}, Description = {1}", attribute.Type, attribute.Description);
            }
        }
    }
}