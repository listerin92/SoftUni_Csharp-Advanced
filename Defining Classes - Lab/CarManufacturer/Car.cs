using System;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tire;

        /// <summary>
        /// Creating a Car
        /// </summary>
        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;

        }
        /// <summary>
        /// Creating a Car with make model year
        /// </summary>
        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        /// <summary>
        /// Creating a Car with make model year fuelquantity fuelconsumption
        /// </summary>
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine,
            Tire[] tires) : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;

        }
        /// <summary>
        /// Add Make
        /// </summary>
        public string Make
        {
            get { return this.make; }
            set
            {
                //if (value.Length < 2)
                //{
                //    throw new ArgumentException("Make should be at least 2 symbol long!");
                //}
                this.make = value;
            }
        }
        public string Model
        {
            get { return this.model; }
            set
            {
                //if (value.Length < 1)
                //{
                //    throw new ArgumentException("Model should be at least 1 symbol long!");
                //}

                this.model = value;
            }
        }

        public int Year
        {
            get { return this.year; }

            set

            {
                var nowYear = DateTime.Now.Year + 100;
                //if (value < 1950 || value > nowYear)
                //{
                //    throw new ArgumentException("It should be between 1950 and {nowYear}");

                //}

                this.year = value;
            }
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel could not be below 0");
                }

                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            bool canContinue = this.FuelQuantity - (distance * this.FuelConsumption / 100) >= 0;
            if (canContinue)
            {
                this.FuelQuantity -= distance * this.FuelConsumption / 100;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");

            }
        }

        public string WhoAmI()
        {
            var result = new StringBuilder();

            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.Append($"Fuel: {this.FuelQuantity:F2}L");

            return result.ToString();
        }
        public string WhoAmISpecialCar()
        {
            var result = new StringBuilder();

            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            result.Append($"FuelQuantity: {this.FuelQuantity:F1}");

            return result.ToString();
        }
    }
}
