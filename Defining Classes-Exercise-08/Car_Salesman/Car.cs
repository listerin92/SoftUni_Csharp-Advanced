using System.Text;

namespace Car_Salesman
{
    public class Car
    {
        private const string DefaultValueString = "n/a";
        private const int DefaultValueInt = -1;
        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }
        public Car(string model, Engine engine, int weight)
            : this(model, engine, weight, DefaultValueString)
        {
        }
        public Car(string model, Engine engine, string color)
            : this(model, engine, DefaultValueInt, color)
        {
        }
        public Car(string model, Engine engine)
            : this(model, engine, DefaultValueInt, DefaultValueString)
        {
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine(Engine.ToString());
            sb.AppendLine(this.Weight == -1 ? $"  Weight: n/a" : $"  Weight: {this.Weight}");
            sb.Append($"  Color: {this.Color}");
            return sb.ToString();
        }
    }
}
