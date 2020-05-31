using System;
using System.Text;
using CarManufacturer;

namespace DefiningClasses
{
    public class Car
    {


        private string _model;
        private double _fuelAmount;

        /// <summary>
        /// Creating a Car
        /// </summary>
        public Car()
        {

            this.Model = "Golf";
            this.FuelAmount = 200;
            this.FuelConsumptionPerKilometer = 10;

        }
        /// <summary>
        /// Creating a Car with make model year
        /// </summary>
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer) : this()
        {

            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.Travelleddistance = 0;
        }

        /// <summary>
        /// Add Model
        /// </summary>
        public string Model
        {
            get => this._model;
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Model should be at least 1 symbol long!");
                }

                this._model = value;
            }
        }

        public double FuelAmount
        {
            get => this._fuelAmount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel could not be below 0");
                }

                this._fuelAmount = value;
            }
        }

        public double FuelConsumptionPerKilometer { get; set; }
        public double Travelleddistance { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        /// <summary>
        /// Calculate remaining Fuel, and travel distance. Return false if not possible to drive
        /// </summary>
        public bool Drive(double distance)
        {
            bool canContinue = this.FuelAmount - (distance * this.FuelConsumptionPerKilometer) >= 0;
            if (canContinue)
            {
                this.FuelAmount -= distance * this.FuelConsumptionPerKilometer;
                this.Travelleddistance += distance;
                return true;
            }

            return false;
        }

        public string WhoAmI()
        {
            var result = new StringBuilder();

            result.AppendLine($"Model: {this.Model}");
            result.Append($"Fuel: {this.FuelAmount:F2}L");

            return result.ToString();
        }
        public string WhoAmISpecialCar()
        {
            var result = new StringBuilder();

            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            result.Append($"FuelAmount: {this.FuelAmount:F1}");

            return result.ToString();
        }
    }
}