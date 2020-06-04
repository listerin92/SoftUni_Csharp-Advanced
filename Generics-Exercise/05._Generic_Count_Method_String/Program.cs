using System;
using System.Linq;

namespace _05._Generic_Count_Method_String
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Box<string> boxes = new Box<string>();
            for (int i = 0; i < length; i++)
            {
                string lines = Console.ReadLine();
                boxes.Add(lines);
            }

            string comparedItem = Console.ReadLine();
            int result = boxes.GetCountGreater(comparedItem);
            Console.WriteLine(result);
        }
    }
}
