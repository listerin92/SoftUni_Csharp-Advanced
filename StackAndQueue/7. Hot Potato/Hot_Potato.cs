using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _7._Hot_Potato
{
    class Hot_Potato
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int tosses = int.Parse(Console.ReadLine());
            Queue<string> kids = new Queue<string>(input.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            while (kids.Count > 1)
            {
                for (int i = 1; i < tosses; i++)
                {
                    kids.Enqueue(kids.Dequeue());
                }
                Console.WriteLine($"Removed {kids.Dequeue()}");
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
