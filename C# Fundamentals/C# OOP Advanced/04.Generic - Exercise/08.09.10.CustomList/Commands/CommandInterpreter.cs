using System;
using _08._09._10.CustomList.Models;

namespace _08._09._10.CustomList.Commands
{
    public class CommandInterpreter
    {
        private readonly CustomList<string> customList = new CustomList<string>();
        private readonly Sorter<string> sorter = new Sorter<string>();

        public void ProcessCommand(string line)
        {
            var tokens = line.Split();
           
            switch (tokens[0])
            {
                case "Add":
                    customList.Add(tokens[1]);
                    break;
                case "Remove":
                    customList.Remove(int.Parse(tokens[1]));
                    break;
                case "Contains":
                    Console.WriteLine(customList.Contains(tokens[1]));
                    break;
                case "Swap":
                    customList.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                    break;
                case "Greater":
                    Console.WriteLine(customList.CountGreaterThan(tokens[1]));
                    break;
                case "Max":
                    Console.WriteLine(customList.Max());
                    break;
                case "Min":
                    Console.WriteLine(customList.Min());
                    break;
                case "Print":
                    foreach (var element in customList.Data)
                    {
                        Console.WriteLine(element.ToString());
                    }
                    break;
                case "Sort":
                    customList.Data = Sorter<string>.Sort(customList.Data);
                    break;
                default:
                    break;
            }
        }
    }
}