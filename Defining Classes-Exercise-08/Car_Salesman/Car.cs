using System.Text;

namespace Car_Salesman
{

    /*
     * Car has the following properties:
•	Model
•	Engine
•	Weight 
•	Color
Engine has the following properties:
•	Model
•	Power
•	Displacement
•	Efficiency

     */

    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }
        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }
        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            this.Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        
    }
}
