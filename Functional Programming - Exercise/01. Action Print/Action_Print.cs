using System;
using System.Linq;

namespace _01._Action_Print
{
    class Action_Print
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> Print = Console.WriteLine;

            foreach (var names in input)
            {
                Print(names);

            }
        }
    }
}
