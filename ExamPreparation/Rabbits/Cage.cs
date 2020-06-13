using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private readonly List<Rabbit> data;
        private Cage()
        {
            this.data = new List<Rabbit>();
        }
        public Cage(string name, int capacity) : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;
        public void Add(Rabbit rabbit)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            Rabbit rabbit = data.FirstOrDefault(x => x.Name == name);
            if (rabbit != null)
            {
                this.data.Remove(rabbit);
                return true;
            }

            return false;
        }
        public void RemoveSpecies(string species)
        {
            this.data.RemoveAll(x => x.Species == species);
        }
        public Rabbit SellRabbit(string name)
        {
            var rabbit = this.data.FirstOrDefault(x => x.Name == name);
            if (rabbit != null)
            {
                rabbit.Available = false;
            }
            return rabbit;

        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] rabbits = this.data.Where(x => x.Species == species).ToArray();
            foreach (var rabbit in rabbits)
            {
                rabbit.Available = false;
            }
            return rabbits;

        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var rabbit in this.data.Where(x => x.Available))
            {
                sb.AppendLine(rabbit.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}