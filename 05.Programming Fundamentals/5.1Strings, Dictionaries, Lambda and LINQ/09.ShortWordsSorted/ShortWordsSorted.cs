using System;

namespace _09.ShortWordsSorted
{
    using System.Linq;

    public class ShortWordsSorted
    {
        public static void Main()
        {
            char[] separators =
                                    {
                                        ' ', '.', ',', ':', ';', '(', ')', '[', ']', '\'', '\"', '\\', '/', '!', '?'
                                    };
            string[] input = Console.ReadLine().ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            var result = input.Where(w => w.Length < 5).OrderBy(w => w).Distinct();

            Console.WriteLine(String.Join(", ", result));
        }
    }
}