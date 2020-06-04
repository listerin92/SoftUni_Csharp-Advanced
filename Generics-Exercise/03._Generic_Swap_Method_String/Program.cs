using System;
using System.Linq;

namespace _03._Generic_Swap_Method_String
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

            int[] swapIndexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            boxes.Swap(swapIndexes[0], swapIndexes[1]);
            Console.WriteLine(boxes.ToString());
        }
    }
}