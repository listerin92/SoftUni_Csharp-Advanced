using System;
using System.Linq;

namespace _2._Sum_Numbers
{
    class Sum_Numbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(input.Count());
            Console.WriteLine(input.Sum());

        }
    }
}
