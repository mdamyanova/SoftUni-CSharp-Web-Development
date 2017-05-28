using System;
using System.Collections.Generic;

namespace _06.AMinerTask
{
    public class AMinerTask
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var resources = new Dictionary<string, int>();

            while (input != "stop")
            {
                var quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(input))
                {
                    resources[input] = quantity;
                }
                else
                {
                    resources[input] += quantity;
                }

                input = Console.ReadLine();
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}