using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parenthesis_Excersize
{
    class Balanced_Parenthesis_Excersize
    {
        static void Main(string[] args)
        {
            char[] parentheses = Console.ReadLine().ToCharArray();

            Stack<char> openParentheses = new Stack<char>();
            bool isBalanced = true;
            foreach (var c in parentheses)
            
            {
                if (c == '{' || c == '(' || c == '[')
                {
                    openParentheses.Push(c);
                }
                else
                {

                    if (!openParentheses.Any())
                    {
                        isBalanced = false;
                        break;

                    }
                    char currentOpenParentheses = openParentheses.Pop();

                    bool isRoundBalanced = currentOpenParentheses == '(' && c == ')';
                    bool isCurlyBalanced = currentOpenParentheses == '{' && c == '}';
                    bool isSquaredBalanced = currentOpenParentheses == '[' && c == ']';

                    if (!isRoundBalanced && !isCurlyBalanced && !isSquaredBalanced)
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
