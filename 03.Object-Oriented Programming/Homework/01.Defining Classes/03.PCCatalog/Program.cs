using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PCCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
           List<Computer> comps = new List<Computer>();
           Computer comp = new Computer("HP 450 G2 ProBook", 
           new Component("1 TB", 200.9M),
           new Component("Intel Core i7-4510U", "2.00 - 3.10 GHz, 4MB cache", 350.12M), 
           1100);
           Computer comp2 = new Computer("HP 450 G2 ProBook", 1254.54M);

           comps.Add(comp);
           comps.Add(comp2);

           comps.OrderBy(p => p.Price);

            foreach (Computer c in comps)
            {
                Console.WriteLine(c);
            }
        }
    }
}