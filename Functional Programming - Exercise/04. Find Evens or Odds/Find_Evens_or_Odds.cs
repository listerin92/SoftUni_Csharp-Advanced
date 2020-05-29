using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Find_Evens_or_Odds
    {
        static void Main(string[] args)
        {
            var rangeArgs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string type = Console.ReadLine();

            int startN = rangeArgs[0];
            int endN = rangeArgs[1];
            List<int> collection = new List<int>();
            for (int i = startN; i <= endN; i++)
            {
                collection.Add(i);
            }

            Predicate<int> checkEvenOdd = x => type == "odd" ? x % 2 != 0 : x % 2 == 0;
            Func<int, bool> CheckEvenOdd = x => type == "odd" ? x % 2 != 0 : x % 2 == 0;

            Console.WriteLine(string.Join(" ", collection.Where(x => checkEvenOdd(x))));
            //Console.WriteLine(string.Join(" ", collection.Where(CheckEvenOdd)));
        }
    }
}
