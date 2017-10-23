using System;

namespace _05.BooleanVariable
{
    public class Boolean
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            bool boolean = Convert.ToBoolean(input);

            if (boolean)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}