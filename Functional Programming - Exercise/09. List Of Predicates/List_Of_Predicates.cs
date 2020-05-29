using System;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class List_Of_Predicates
    {
        static void Main(string[] args)
        {
            var range = int.Parse(Console.ReadLine());
            var divisors = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] numRange = new int[range];

            Func<int, bool>[] predicates = divisors.Select(div => (Func<int, bool>)(n => n % div == 0)).ToArray();

            for (int j = 1; j <= range; j++)
            {
                bool isDivisable = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(j))
                    {
                        isDivisable = false;
                        break;
                    }
                }

                if (isDivisable)
                {
                    Console.Write("{0} ", j);
                }
            }
        }
    }
}
