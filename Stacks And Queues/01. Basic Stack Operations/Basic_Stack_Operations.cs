using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Basic_Stack_Operations
    {
        static void Main()
        {
            string[] lineArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            int n = int.Parse(lineArr[0]);
            int s = int.Parse(lineArr[1]);
            int x = int.Parse(lineArr[2]);
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }

            int count = Math.Min(s, stack.Count);

            while (count > 0)
            {
                stack.Pop();
                count--;
            }

            if (stack.Count > 0)
            {
                if (stack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else if (!stack.Contains(x))
                {
                    Console.WriteLine(stack.Min());
                }
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
        }
    }
}
