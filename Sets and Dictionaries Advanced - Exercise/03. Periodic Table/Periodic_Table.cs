using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Periodic_Table
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var chemElements = new HashSet<string>();
            for (int i = 0; i < lines; i++)
            {
                var chemLine = Console.ReadLine().Split().ToArray();
                foreach (var item in chemLine)
                {
                    chemElements.Add(item);
                }
            }
            foreach (var item in chemElements.OrderBy(o=>o))
            {
                Console.Write($"{item} ");
            }
        }
    }
}
