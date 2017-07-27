using System;
using System.Linq;

namespace _01.ListyIterator
{
    public class Program
    {
        public static void Main()
        {
            var createCommand = Console.ReadLine().Split();
            ListyIterator<string> listyIterator;

            if (createCommand.Length > 1)
            {
                var tokens = createCommand.Skip(1).ToList();
                listyIterator = new ListyIterator<string>(tokens);
            }
            else
            {
                listyIterator = new ListyIterator<string>();
            }

            var input = Console.ReadLine(); 

            while (input != "END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}