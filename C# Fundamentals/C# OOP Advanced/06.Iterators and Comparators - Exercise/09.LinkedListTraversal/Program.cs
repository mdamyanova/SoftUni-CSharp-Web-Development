using System;

namespace _09.LinkedListTraversal
{
    public class Program
    {
        public static void Main()
        {
            var linkedList = new LinkedList<int>();
            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var tokens = Console.ReadLine().Split();
                var number = int.Parse(tokens[1]);

                switch (tokens[0])
                {
                    case "Add":
                        linkedList.Add(number);
                        break;
                    case "Remove":
                        linkedList.Remove(number);
                        break;
                }
            }

            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(" ", linkedList));
        }
    }
}