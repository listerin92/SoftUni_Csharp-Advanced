using System.Collections.Generic;

namespace Pokemon_Trainer
{
    public class Trainer
    {
        private const int DefaultBadges = 0;
        private const int DefaultPokemons = 0;

        public Trainer(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
            this.NumberOfBadges = DefaultBadges;
            this.CollectionOfPokemon = DefaultPokemons;
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public int CollectionOfPokemon { get; set; }
        public List<Pokemon> Pokemons { get; }
    }
}
