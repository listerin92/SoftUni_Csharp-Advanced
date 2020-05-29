using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Knights_of_Honor
    {
        static void Main(string[] args)
        {
            Action<string> Print = x => Console.WriteLine("Sir " + x);

            Func<string, string> format = x => $"Sir {x}";
            Action<List<string>> print = x => Console.WriteLine(string.Join(Environment.NewLine,
                x.Select(format)));

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(Print);
        }
    }
}
