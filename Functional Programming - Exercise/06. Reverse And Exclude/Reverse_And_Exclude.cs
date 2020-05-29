using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Reverse_And_Exclude
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var divisor = int.Parse(Console.ReadLine());

            Action<List<int>> Print = x => Console.Write(string.Join(" ", x));

            int count = numbers.Count - 1;
            while (count >= 0)
            {
                if (numbers[count] % divisor == 0)
                {
                    numbers.Remove(numbers[count]);
                }
                count--;
            }

            numbers = numbers.ToArray().Reverse().ToList();

            Print(numbers);

        }
    }
}
