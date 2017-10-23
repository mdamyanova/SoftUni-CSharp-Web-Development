using System;

namespace _10.PalindromeIndex
{
    public class PalindromeIndex
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (IsPalindrome(input))
            {
                Console.WriteLine(-1);
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    string temp = input.Remove(i, 1);

                    if (IsPalindrome(temp))
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
            }
        }

        static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}