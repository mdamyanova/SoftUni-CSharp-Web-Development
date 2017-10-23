using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PokemonTrainer
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var trainers = new List<Trainer>();

            while (input != "Tournament")
            {
                var tokens = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var trainerName = tokens[0];
                var pokemonName = tokens[1];
                var pokemonElement = tokens[2];
                var pokemonHealth = int.Parse(tokens[3]);

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.FirstOrDefault(t => t.Name == trainerName) == null)
                {
                    //we don't have the trainer, add it
                    var trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
                else
                {
                    //we already have the trainer, add pokemon
                    trainers.FirstOrDefault(t => t.Name == trainerName).Pokemons.Add(pokemon);
                }

                input = Console.ReadLine();
            }

            var line = Console.ReadLine();

            while (line != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.FirstOrDefault(p => p.Element == line) == null)
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                    else
                    {
                        trainer.Badges++;
                    }        
                }

                line = Console.ReadLine();
            }

            var sortedTrainers = trainers.OrderByDescending(t => t.Badges).ToList();
            foreach (var trainer in sortedTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}