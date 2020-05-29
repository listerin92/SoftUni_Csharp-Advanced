namespace _03._Custom_Min_Function
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Custom_Min_Function
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> MinNumber = x => x.Min();

            var min = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            Console.WriteLine(MinNumber(min));


        }
    }
}
