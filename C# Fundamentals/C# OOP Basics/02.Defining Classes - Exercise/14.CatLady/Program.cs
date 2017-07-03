using System;
using System.Collections.Generic;
using System.Linq;
using _14.CatLady.Models;

namespace _14.CatLady
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var cats = new List<Cat>();

            while (input[0] != "End")
            {
                switch (input[0])
                {
                    case "Siamese":
                        var siamese = new Siamese(input[1], double.Parse(input[2]));
                        cats.Add(siamese);
                        break;
                    case "Cymric":
                        var cymric = new Cymric(input[1], double.Parse(input[2]));
                        cats.Add(cymric);
                        break;
                    case "StreetExtraordinaire":
                        var streetExtraordinaire = new StreetExtraordinaire(input[1], double.Parse(input[2]));
                        cats.Add(streetExtraordinaire);
                        break;             
                }

                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var catName = Console.ReadLine();
            Console.WriteLine(cats.FirstOrDefault(c => c.Name == catName).ToString());
        }
    }
}