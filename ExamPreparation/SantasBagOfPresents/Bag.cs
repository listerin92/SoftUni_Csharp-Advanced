using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;
        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>();

        }

        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;
        public void Add(Present present)
        {
            if (this.data.Count < this.Capacity)
            {
                data.Add(present);
            }
        }
        public bool Remove(string name)
        {
            Present present = data.Find(x => x.Name == name);
            if (present == null) return false;
            data.Remove(present);
            return true;
        }

        public Present GetHeaviestPresent()
        {
            return this.data.OrderByDescending(p => p.Weight).First();
        }

        public Present GetPresent(string name)
        {
            return this.data.Find(p => p.Name == name);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");
            foreach (var present in this.data)
            {
                sb.AppendLine($"{present}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
