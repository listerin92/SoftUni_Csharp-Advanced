using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Predicate_For_Names
    {
        static void Main(string[] args)
        {
            var numbers = int.Parse(Console.ReadLine());
            Predicate<string> nameLength = x => x.Length <= numbers;

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .Where(x => nameLength(x))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
