using System;

namespace _15.MelrahShake
{
    public class MelrahShake
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (text.Contains(pattern) && text.IndexOf(pattern) != text.LastIndexOf(pattern) && pattern.Length > 0)
            {
                var left = text.IndexOf(pattern);
                text = text.Remove(left, pattern.Length);

                var right = text.LastIndexOf(pattern);
                text = text.Remove(right, pattern.Length);

                pattern = pattern.Remove(pattern.Length / 2, 1);
                Console.WriteLine("Shaked it.");
            }

            Console.WriteLine("No shake.");
            Console.WriteLine(text);
        }
    }
}