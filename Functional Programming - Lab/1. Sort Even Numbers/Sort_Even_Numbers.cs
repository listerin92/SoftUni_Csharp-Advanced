using System;
using System.Linq;

namespace _1._Sort_Even_Numbers
{
    class Sort_Even_Numbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderBy(x => x)
                .Where(x => x % 2 == 0)
                .ToList();
            Console.Write(string.Join(", ", input));


        }
    }
}
