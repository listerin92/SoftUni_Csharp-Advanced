using System;
using System.Collections.Generic;
using System.Linq;
using DefiningClasses;

namespace Raw_Data
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int noOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < noOfCars; i++)
            {
                var carLine = Console.ReadLine().Split();
                var model = carLine[0];
                var engineSpeed = int.Parse(carLine[1]);
                var enginePower = int.Parse(carLine[2]);
                var cargoWeight = int.Parse(carLine[3]);
                var cargoType = carLine[4];
                var tire1Pressure = double.Parse(carLine[5]);
                var tire1Age = int.Parse(carLine[6]);
                var tire2Pressure = double.Parse(carLine[7]);
                var tire2Age = int.Parse(carLine[8]);
                var tire3Pressure = double.Parse(carLine[9]);
                var tire3Age = int.Parse(carLine[10]);
                var tire4Pressure = double.Parse(carLine[11]);
                var tire4Age = int.Parse(carLine[12]);

                Car car = new Car(model, engineSpeed, enginePower,
                    cargoWeight, cargoType,
                    tire1Pressure, tire1Age,
                    tire2Pressure, tire2Age,
                    tire3Pressure, tire3Age,
                    tire4Pressure, tire4Age);
                cars.Add(car);
            }

            string cargoTypeCheck = Console.ReadLine();

            Print(cargoTypeCheck, cars);
        }

        private static void Print(string cargoTypeCheck, List<Car> cars)
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
