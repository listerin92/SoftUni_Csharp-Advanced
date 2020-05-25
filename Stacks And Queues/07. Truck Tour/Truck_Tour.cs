using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Truck_Tour
    {
        static void Main(string[] args)
        {
            int noOfStations = int.Parse(Console.ReadLine());

            Queue<GasStation> gasStations = new Queue<GasStation>();


            for (int i = 0; i < noOfStations; i++)
            {

                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                GasStation currentGasStation = new GasStation(input[0], input[1]);
                gasStations.Enqueue(currentGasStation);
            }

            for (int i = 0; i < noOfStations; i++)
            {
                int currentFuel = gasStations.Peek().Petrol;

                for (int x = 0; x < noOfStations; x++)
                {
                    int distanceToNextGas = gasStations.Peek().Distance;

                    if (distanceToNextGas <= currentFuel)
                    {

                        currentFuel -= distanceToNextGas;
                        if (x == noOfStations - 1)
                        {
                            Console.WriteLine(i);
                            return;
                        }

                    }
                    else
                    {
                        for (int y = x; y < noOfStations; y++)
                        {
                            gasStations.Enqueue(gasStations.Dequeue());
                        }

                        break;
                    }
                    gasStations.Enqueue(gasStations.Dequeue());
                    currentFuel += gasStations.Peek().Petrol;
                }
                gasStations.Enqueue(gasStations.Dequeue());
            }
        }

    }

    class GasStation
    {
        public GasStation(int petrol, int distance)
        {
            Petrol = petrol;
            Distance = distance;
        }
        public int Petrol { get; set; }
        public int Distance { get; set; }
    }
}

