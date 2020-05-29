using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Custom_Comparator
    {
        static void Main(string[] args)
        {
            Func<int, int, int> sortFunc = (a, b) =>
                (a % 2 == 0 && b % 2 != 0) ? -1 :
                (a % 2 != 0 && b % 2 == 0) ? 1 :
                a.CompareTo(b);

            Action<int[]> print = x => Console.WriteLine($"{string.Join(" ", x)}");
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, new Comparison<int>(sortFunc));

            print(numbers);
        }

    }
}
