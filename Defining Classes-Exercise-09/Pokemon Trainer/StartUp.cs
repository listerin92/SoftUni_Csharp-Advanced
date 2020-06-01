using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Trainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var trainers = new List<Trainer>();
            input = Input(input, trainers);

            input = Console.ReadLine();

            ProcessHealthAndBadges(input, trainers);

            RemoveZeroHealth(trainers);

            trainers.OrderByDescending(x => x.NumberOfBadges)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} {x.NumberOfBadges} {x.Pokemons.Count}"));
        }

        private static void RemoveZeroHealth(List<Trainer> trainers)
        {
            foreach (var trainer in trainers)
            {
                trainer.Pokemons.RemoveAll(x => x.Health <= 0);
            }
        }

        private static void ProcessHealthAndBadges(string input, List<Trainer> trainers)
        {
            while (input != "End")
            {
                foreach (var currentTrainer in trainers)
                {
                    if (currentTrainer.Pokemons.All(y => y.Element != input)) // could be more clear !!!!!!!
                    {
                        foreach (var currentPokemon in currentTrainer.Pokemons)
                        {
                            currentPokemon.ReduceHealth();
                        }
                    }
                    else
                    {
                        currentTrainer.NumberOfBadges++;
                    }
                }
                input = Console.ReadLine();
            }
        }

        private static string Input(string input, List<Trainer> trainers)
        {
            while (input != "Tournament")
            {
                var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var trainerName = tokens[0];
                var pokemonName = tokens[1];
                var pokemonElement = tokens[2];
                var pokemonHealth = int.Parse(tokens[3]);
                var trainer =
                    trainers.FirstOrDefault(x => x.Name == trainerName); //check in List<Trainer> if trainerName exist !!!

                if (trainer != null) // if exist only add the Pokemon
                {
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }
                else // if not exist add new Trainer + the Pokemon
                {
                    var newTrainer = new Trainer(trainerName);
                    newTrainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                    trainers.Add(newTrainer);
                }

                //trainers.Add(trainer);
                input = Console.ReadLine();
            }

            return input;
        }
    }
}
