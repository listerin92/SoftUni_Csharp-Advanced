using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matching_Brackets
{
    class Matching_Brackets
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    int start = stack.Pop();
                    Console.WriteLine(input.Substring(start, i - start + 1));
                }
            }

        }
    }
}
