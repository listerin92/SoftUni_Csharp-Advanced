using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Balanced_Parenthesis
    {
        static void Main(string[] args)
        {
            char[] parentheses = Console.ReadLine().ToCharArray();

            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> closingBrackets = new Dictionary<char, char>()
            {
                {
                    ']', '['
                },
                {
                    ')', '('
                },
                {
                    '}', '{'
                }
            };
            foreach (var bracket in parentheses)
            {
                if (stack.Count > 0 && closingBrackets.ContainsKey(bracket) && stack.Peek() == closingBrackets[bracket])
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(bracket);
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}