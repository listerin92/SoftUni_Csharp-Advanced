using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Print_Even_Numbers
    {
        static void Main(string[] args)
        {
            Queue<int> queueNew = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(Int32.Parse)
                .Where(w => w % 2 == 0));
            Console.WriteLine(string.Join(", ", queueNew.ToArray()));

        }
    }
}
