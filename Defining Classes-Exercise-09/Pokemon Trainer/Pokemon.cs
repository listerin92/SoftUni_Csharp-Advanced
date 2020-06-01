﻿namespace Pokemon_Trainer
{
    public class Pokemon
    {
        public Pokemon()
        {

        }
        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
        public void ReduceHealth()
        {
            this.Health -= 10;
        }
    }
}
