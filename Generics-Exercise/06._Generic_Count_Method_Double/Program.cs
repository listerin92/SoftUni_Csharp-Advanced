using System;

namespace _06._Generic_Count_Method_Double
{
    class Program
    {
        static void Main(string[] args)
        {

            int length = int.Parse(Console.ReadLine());
            Box<double> boxes = new Box<double>();
            for (int i = 0; i < length; i++)
            {
                double lines = double.Parse(Console.ReadLine());
                boxes.Add(lines);
            }

            double comparedItem = double.Parse(Console.ReadLine());
            int result = boxes.GetCountGreater(comparedItem);
            Console.WriteLine(result);
        }
    }
}
    