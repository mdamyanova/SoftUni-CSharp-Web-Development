using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Palindromes
{
    public class Palindromes
    {
        public static void Main()
        {
            var delimeters = ". ,?!\\/';:[]()".ToCharArray();
            var words = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x).ToArray();
            var unique = new HashSet<string>();

            foreach (string t in words)
            {
                var isPalindrome = true;
                for (int j = 0, k = t.Length - 1; j < k; j++, k--)
                {
                    if (t[j] != t[k])
                    {
                        isPalindrome = false;
                        break;
                    }
                }

                if (isPalindrome && !unique.Contains(t))
                {
                    unique.Add(t);
                }
            }

            Console.Write("[");
            Console.Write(string.Join(", ", unique));
            Console.Write("]");
            Console.WriteLine();
        }
    }
}