using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
    class Parking_Lot
    {
        static void Main(string[] args)
        {
            var parking = new HashSet<string>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                var tokens = line.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = tokens[0];
                var plateNo = tokens[1];

                if (command == "IN")
                {
                    parking.Add(plateNo);
                }
                else
                {
                    parking.Remove(plateNo);
                }

            }
            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var item in parking)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
