using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Count_Uppercase_Words
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToList()
                   .Where(UpperCaseWordChecker)
                   .ToList()
                   .ForEach(Console.WriteLine);
        }

        private static readonly Func<string, bool> UpperCaseWordChecker = x => Char.IsUpper(x[0]);
    }
}
