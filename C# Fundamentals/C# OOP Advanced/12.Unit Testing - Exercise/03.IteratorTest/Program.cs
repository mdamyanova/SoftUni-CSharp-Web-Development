using System;
using System.Linq;

namespace _03.IteratorTest
{
    public class Program
    {
        public static void Main()
        {
            var createCommand = Console.ReadLine().Split().ToList();
            var listIterator = new ListIterator(createCommand.Skip(1).ToArray());

            var command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    switch (command)
                    {
                        case "Move":
                            Console.WriteLine(listIterator.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(listIterator.HasNext());
                            break;
                        case "Print":
                            Console.WriteLine(listIterator.Print());
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}