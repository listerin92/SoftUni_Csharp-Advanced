using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarManufacturer;
using Raw_Data;

namespace DefiningClasses
{
    public class Car
    {

        private string _model;
        private double _fuelAmount;
        private Cargo _cargo = new Cargo();

        /// <summary>
        /// Creating a Car with Model, EngineSpeed, EngineHorsePower, CargoWeight, CargoType and Tire Array
        /// </summary>
        public Car(string model, int engineSpeed,
            int enginePower, int weight, string cargoType,
            Tire[] tires)
        {
            this.Model = model;
            this.Engine.EngineSpeed = engineSpeed;
            this.Engine.HorsePower = enginePower;
            this.Cargo.CargoWeight = weight;
            this.Cargo.CargoType = cargoType;
            this.Tires = tires;
        }
        /// <summary>
        /// Creating a Car with Model, EngineSpeed, EngineHorsePower, CargoWeight, CargoType and 4 tires with pressure and age
        /// </summary>
        public Car(string model, int engineSpeed, int enginePower,
            int weight, string cargoType,
            double tire1Pressure, int tire1Age,
            double tire2Pressure, int tire2Age,
            double tire3Pressure, int tire3Age,
            double tire4Pressure, int tire4Age)
        {
            this.Model = model;
            this.Engine.EngineSpeed = engineSpeed;
            this.Engine.HorsePower = enginePower;
            this.Cargo.CargoWeight = weight;
            this.Cargo.CargoType = cargoType;
            this.Tires[0] = new Tire(tire1Pressure, tire1Age);
            this.Tires[1] = new Tire(tire2Pressure, tire2Age);
            this.Tires[2] = new Tire(tire3Pressure, tire3Age);
            this.Tires[3] = new Tire(tire4Pressure, tire4Age);
        }

        /// <summary>
        /// Setting Model
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
        /// <summary>
        /// Setting FuelAmount
        /// </summary>
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

        public Engine Engine { get; set; } = new Engine(0, 0);

        public Cargo Cargo
        {
            get => _cargo;
            set => _cargo = value;
        }

        public Tire[] Tires { get; set; } = new Tire[4];

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

        /// <summary>
        /// Print WhoAmI
        /// </summary>
        /// <returns>string</returns>
        public string WhoAmI()
        {
            var result = new StringBuilder();

            result.AppendLine($"Model: {this.Model}");
            result.Append($"Fuel: {this.FuelAmount:F2}L");

            return result.ToString();
        }
        /// <summary>
        /// Print WhoAmISpecialCar
        /// </summary>
        /// <returns>string</returns>
        public string WhoAmISpecialCar()
        {
            var result = new StringBuilder();

            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            result.Append($"FuelAmount: {this.FuelAmount:F1}");

            return result.ToString();
        }
        public static void Print(string cargoTypeCheck, List<Car> cars)
        {
            if (cargoTypeCheck == "fragile")
            {
                cars.Where(x => x.Cargo.CargoType == cargoTypeCheck)
                    .Where(x => x.Tires.Any(t => t.Pressure < 1))
                    .ToList().ForEach(x => Console.WriteLine(x.Model));
            }
            else
            {
                cars.Where(x => x.Cargo.CargoType == cargoTypeCheck)
                    .Where(x => x.Engine.HorsePower > 250)
                    .ToList().ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
}