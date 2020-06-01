using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car_Salesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int engineNo = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            InputEngines(engineNo, engines);

            int carNo = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            InputCars(carNo, engines, cars);

            //foreach (var car in cars)
            //{
            //    Console.WriteLine($"{car.Model}:");
            //    Console.WriteLine($"  {car.Engine.Model}:");
            //    Console.WriteLine($"    Power: {car.Engine.Power}");
            //    Console.WriteLine("    Displacement: {0}", car.Engine.Displacement == 0 ? "n/a" : car.Engine.Displacement.ToString());
            //    Console.WriteLine("    Efficiency: {0}", car.Engine.Efficiency == "" ? "n/a" : car.Engine.Efficiency.ToString());
            //    Console.WriteLine("  Weight: {0}", car.Weight == 0 ? "n/a" : car.Weight.ToString());
            //    Console.WriteLine("  Color: {0}", car.Color == "" ? "n/a" : car.Color.ToString());
            //}

            // only way to override toString is to create constructors with 1 or 2 default elements !! - for optional fields
            // only checking -1 on both Engine and Car to substitute with n/a
            // otherwise logics will be like it set above

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }


        private static void InputCars(int carNo, List<Engine> engines, List<Car> cars)
        {
            for (int i = 0; i < carNo; i++)
            {
                var carTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var carModel = carTokens[0];
                var engineModel = carTokens[1];
                var carEngine = engines.First(x => x.Model == engineModel);

                Car car = null;

                if (carTokens.Length == 2) // third token could be weight or color
                {
                    car = new Car(carModel, carEngine);
                }

                if (carTokens.Length == 3) // third token could be weight or color
                {
                    bool tryCarWeight = int.TryParse(carTokens[2], out var carWeight);
                    if (!tryCarWeight)
                    {
                        var carColor = carTokens[2];
                        car = new Car(carModel, carEngine, carColor);
                    }
                    else
                    {
                        car = new Car(carModel, carEngine, carWeight);
                    }
                }

                if (carTokens.Length == 4) // when we got 4 tokens they are at the correct order
                {
                    var carWeight = int.Parse(carTokens[2]);
                    var carColor = carTokens[3];
                    car = new Car(carModel, carEngine, carWeight, carColor);
                }
                cars.Add(car);
            }
        }

        private static void InputEngines(int engineNo, List<Engine> engines)
        {
            for (int i = 0; i < engineNo; i++)
            {
                var engineTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var engineModel = engineTokens[0];
                var enginePower = int.Parse(engineTokens[1]);

                Engine engine = null;
                if (engineTokens.Length == 2)
                {
                    engine = new Engine(engineModel, enginePower);
                }

                else if (engineTokens.Length == 3) // third token could be efficiency or displacement
                {

                    bool tryEngineDisplacement = int.TryParse(engineTokens[2], out int engineDisplacement);
                    if (!tryEngineDisplacement)
                    {
                        var engineEfficiency = engineTokens[2];
                        engine = new Engine(engineModel, enginePower, engineEfficiency);
                    }
                    else
                    {
                        engine = new Engine(engineModel, enginePower, engineDisplacement);
                    }
                }

                else if (engineTokens.Length == 4) // when we got 4 tokens they are at the correct order
                {
                    var engineDisplacement = int.Parse(engineTokens[2]);
                    var engineEfficiency = engineTokens[3];
                    engine = new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency);
                }

                engines.Add(engine);
            }
        }
    }
}
