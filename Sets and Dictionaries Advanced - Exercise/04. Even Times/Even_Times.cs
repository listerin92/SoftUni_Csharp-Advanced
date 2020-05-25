using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Even_Times
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < lines; i++)
            {
                int digit = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(digit))
                {
                    dict[digit] = 0;
                }
                dict[digit]++;
            }
            foreach (var item in dict)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }
        }
    }
}
