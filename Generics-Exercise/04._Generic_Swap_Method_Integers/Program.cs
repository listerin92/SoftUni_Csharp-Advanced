using System;
using System.Linq;

namespace _04._Generic_Swap_Method_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Box<int> boxes = new Box<int>();
            for (int i = 0; i < length; i++)
            {
                int lines = int.Parse(Console.ReadLine());
                boxes.Add(lines);
            }

            int[] swapIndexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            boxes.Swap(swapIndexes[0], swapIndexes[1]);
            Console.WriteLine(boxes.ToString());
        }
    }
}
