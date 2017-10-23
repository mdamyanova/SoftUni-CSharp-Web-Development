using System;

namespace _19.MaxMethod
{
    public class MaxMethod
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMax(a, b, c));       
        }

        private static int GetMax(int a, int b, int c)
        {
            int maxTwo = Math.Max(a, b);
            int maxThree = Math.Max(maxTwo, c);

            return maxThree;
        }
    }
}