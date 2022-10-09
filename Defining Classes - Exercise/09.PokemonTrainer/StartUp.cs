using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> allTrainers = new List<Trainer>();

            string input;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] token = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainderName = token[0];
                string pokemonName = token[1];
                string element = token[2];
                int healght = int.Parse(token[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, healght);

                if (allTrainers.Any(x => x.Name == trainderName))
                {
                    var wantedTrainer = allTrainers.First(x => x.Name == trainderName);
                    wantedTrainer.AllPokemon.Add(pokemon);
                }
                else
                {
                    Trainer trainder = new Trainer(trainderName);
                    trainder.AllPokemon.Add(pokemon);
                    allTrainers.Add(trainder);
                }
            }

            Pokemon pokemonToRemove = null;

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in allTrainers)
                {
                    if (trainer.AllPokemon.Any(x => x.Element == input))
                    {
                        trainer.NumberOfBadges++;
                        continue;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.AllPokemon)
                        {
                            pokemon.Healght -= 10;

                            if (pokemon.Healght <= 0)
                            {
                                pokemonToRemove = pokemon;
                            }
                        }

                        trainer.AllPokemon.Remove(pokemonToRemove);
                    }
                }
            }

            foreach (var trainer in allTrainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.AllPokemon.Count}");
            }
        }
    }
}
