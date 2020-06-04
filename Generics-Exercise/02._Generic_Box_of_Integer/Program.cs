using System;
using System.Collections.Generic;

namespace _02._Generic_Box_of_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                int lines = int.Parse(Console.ReadLine());
                Box<int> boxOfInts = new Box<int>(lines);
                Console.WriteLine(boxOfInts.ToString());

            }
        }
    }
}
