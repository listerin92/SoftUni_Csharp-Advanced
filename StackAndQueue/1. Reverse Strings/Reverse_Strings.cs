using System;
using System.Collections.Generic;

namespace _1._Reverse_Strings
{
    class Reverse_Strings
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reverse = new Stack<char>(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                reverse.Push(input[i]);
            }
            while (reverse.Count > 0)
            {
                Console.Write(reverse.Pop());
            }
            Console.WriteLine();
        }

        
    }

}
