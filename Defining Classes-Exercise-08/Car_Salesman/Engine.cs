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
   public class Engine
    {
        public Engine()
        {

        }
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;

        }
        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;

        }
        public Engine(string model, int power, int displacement, string efficiency) :this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
