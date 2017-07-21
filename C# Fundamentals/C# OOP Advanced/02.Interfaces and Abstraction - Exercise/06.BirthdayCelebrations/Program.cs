using System;
using System.Collections.Generic;
using System.Linq;
using _05.BorderControl;
using _06.BirthdayCelebrations.Interfaces;
using _06.BirthdayCelebrations.Models;

namespace _06.BirthdayCelebrations
{

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var citizensAndPets = new List<IBirthable>();

            while (input != "End")
            {
                var tokens = input.Split();
                IBirthable citizenOrPet = null;

                switch (tokens[0])
                {
                    case "Citizen":
                        citizenOrPet = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                        break;
                    case "Pet":
                        citizenOrPet = new Pet(tokens[1], tokens[2]);
                        break;
                    default:
                        break;
                }

                if (citizenOrPet != null)
                {
                    citizensAndPets.Add(citizenOrPet);
                }

                input = Console.ReadLine();
            }

            var year = Console.ReadLine();

            foreach (var x in citizensAndPets.Where(x => x.Birthdate.EndsWith(year)))
            {
                Console.WriteLine(x.Birthdate);
            }
        }
    }
}
