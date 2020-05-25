using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Traffic_Jam
    {
        static void Main(string[] args)
        {
            int noOfCars = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int counter = 0;
            string token = string.Empty;
            while ((token=Console.ReadLine())!= "end")
            {
                if (token != "green")
                {
                    cars.Enqueue(token);
                }
                else
                {
                    for (int i = 0; i < noOfCars; i++)
                    {
                        string car;
                        if (cars.TryDequeue(out car))
                        {
                            Console.WriteLine($"{car} passed!");
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
