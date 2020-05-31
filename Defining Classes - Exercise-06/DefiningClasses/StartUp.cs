using System;
using System.Collections.Generic;
using System.Linq;
using CarManufacturer;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int noOfLines = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < noOfLines; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                var model = tokens[0];
                var fuelAmount = double.Parse(tokens[1]);
                var fuelConsumptionPer1Km = double.Parse(tokens[2]);
                var car = new Car(model, fuelAmount, fuelConsumptionPer1Km);
                cars.Add(car);
            }

            var commands = Console.ReadLine();
            while (true)
            {
                if (commands == "End")
                {
                    break;
                }
                var tokens = commands.Split(' ');
                var command = tokens[0];
                var model = tokens[1];
                var amountOfKm = double.Parse(tokens[2]);

                if (command == "Drive")
                {
                    foreach (var car in cars)
                    {
                        if (car.Model == model)
                        {
                            bool successfulDrive = car.Drive(amountOfKm);
                            if (!successfulDrive)
                            {
                                Console.WriteLine("Insufficient fuel for the drive");
                            }
                        }
                    }
                }
                commands = Console.ReadLine();
            }
            cars.ForEach(x => Console.WriteLine($"{x.Model} {x.FuelAmount:0.00} {x.Travelleddistance}"));
        }
    }
}
