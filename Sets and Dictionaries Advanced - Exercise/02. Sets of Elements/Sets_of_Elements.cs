using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Sets_of_Elements
    {
        static void Main(string[] args)
        {
            long[] twoSets = Console.ReadLine().Split().Select(long.Parse).ToArray();

            var setOne = new HashSet<long>();
            for (var i = 0; i < twoSets[0]; i++)
            {
                var digit = long.Parse(Console.ReadLine());
                setOne.Add(digit);

            }

            var setTwo = new HashSet<long>();
            for (int i = 0; i < twoSets[1]; i++)
            {
                var digit = long.Parse(Console.ReadLine());
                setTwo.Add(digit);
            }

            Console.WriteLine(string.Join(" ", setOne.Intersect(setTwo)));
        }
        
    }
}
