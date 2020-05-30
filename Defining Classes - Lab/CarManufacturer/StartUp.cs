using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            //Car car = new Car();
            //car.Make = "VW";
            //car.Model = "MK3";
            //car.Year = 1992;
            //car.FuelQuantity = 200;
            //car.FuelConsumption = 200;
            //car.Drive(2000);
            //Console.WriteLine(car.WhoAmI());
            //Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");

            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);


            //var tires = new Tire[4]
            //{
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.1),
            //    new Tire(2, 0.5),
            //    new Tire(2, 2.3)
            //};
            //var engine = new Engine(560, 6300);
            //var car = new Car("Lamborgini", "Strela", 2010, 250, 9, engine, tires);




            string command = Console.ReadLine();
            var tires = new List<Tire[]>();

            while (command != "No more tires")
            {
                var tire = command.Split(' ').ToArray();
                var tire1 = new Tire(int.Parse(tire[0]), double.Parse(tire[1]));
                var tire2 = new Tire(int.Parse(tire[2]), double.Parse(tire[3]));
                var tire3 = new Tire(int.Parse(tire[4]), double.Parse(tire[5]));
                var tire4 = new Tire(int.Parse(tire[6]), double.Parse(tire[7]));

                tires.Add(new Tire[] { tire1, tire2, tire3, tire4 });
                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            var engines = new List<Engine>();

            while (command != "Engines done")
            {
                var eng = command.Split().ToArray();
                Engine engine = new Engine(int.Parse(eng[0]), double.Parse(eng[1]));
                engines.Add(engine);
                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            var cars = new List<Car>();
            while (command != "Show special")
            {
                var carSplit = command.Split().ToArray();

                var make = carSplit[0];
                var model = carSplit[1];
                var year = int.Parse(carSplit[2]);
                var fuelQuantity = double.Parse(carSplit[3]);
                var fuelConsumption = double.Parse(carSplit[4]);
                Engine engineIndex = engines[int.Parse(carSplit[5])];
                Tire[] tiresIndex = tires[int.Parse(carSplit[6])];

                var car = new Car(make, model, year, fuelQuantity, fuelConsumption, engineIndex, tiresIndex);
                cars.Add(car);

                command = Console.ReadLine();
            }

            cars = cars
                .Where(x => x.Year >= 2017
                    && x.Engine.HorsePower > 330 
                    && x.Tires.Sum(y => y.Pressure) >= 9 
                    && x.Tires.Sum(y => y.Pressure)<=10)
                .ToList();

            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmISpecialCar());
            }
        }
    }
}