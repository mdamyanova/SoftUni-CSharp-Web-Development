using System;
using System.Collections.Generic;
using System.Linq;
using _08.PetClinics.Models;

namespace _08.PetClinics
{
    public class Program
    {
        public static void Main()
        {
            var pets = new List<Pet>();
            var clinics = new List<Clinic>();
            var input = string.Empty;
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                try
                {
                    var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var command = tokens[0];
                    tokens.RemoveAt(0);

                    switch (command)
                    {
                        case "Create":
                            if (tokens[0] == "Pet")
                            {
                                pets.Add(new Pet(tokens[1], int.Parse(tokens[2]), tokens[3]));
                            }
                            else if (tokens[0] == "Clinic")
                            {
                                clinics.Add(new Clinic(tokens[1], int.Parse(tokens[2])));
                            }
                            break;
                        case "Add":
                            Console.WriteLine(clinics.First(c => c.Name == tokens[1]).Add(pets.First(p => p.Name == tokens[0])));
                            break;
                        case "Release":
                            Console.WriteLine(clinics.First(c => c.Name == tokens[0]).Release());
                            break;
                        case "HasEmptyRooms":
                            Console.WriteLine(clinics.First(c => c.Name == tokens[0]).HasEmptyRooms());
                            break;
                        case "Print":
                            if (tokens.Count == 1)
                            {
                                clinics.First(c => c.Name == tokens[0]).Print();
                            }
                            else if (tokens.Count > 1)
                            {
                                clinics.First(c => c.Name == tokens[0]).Print(int.Parse(tokens[1]));
                            }
                            break;
                        default:
                            throw new InvalidOperationException("Invalid Operation!");
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}