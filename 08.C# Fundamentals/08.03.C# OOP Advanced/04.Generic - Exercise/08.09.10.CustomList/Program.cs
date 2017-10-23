using System;
using _08._09._10.CustomList.Commands;

namespace _08._09._10.CustomList
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var commandInterpreter = new CommandInterpreter();

            while (input != "END")
            {
                commandInterpreter.ProcessCommand(input);
                input = Console.ReadLine();
            }
        }
    }
}
