using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Basic_Queue_Operations
    {
        static void Main(string[] args)
        {
            string[] lineArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            int n = int.Parse(lineArr[0]);
            int s = int.Parse(lineArr[1]);
            int x = int.Parse(lineArr[2]);
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            int count = Math.Min(s, queue.Count);

            while (count > 0)
            {
                queue.Dequeue();
                count--;
            }

            if (queue.Count > 0)
            {
                if (queue.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else if (!queue.Contains(x))
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
        }
    }
}
