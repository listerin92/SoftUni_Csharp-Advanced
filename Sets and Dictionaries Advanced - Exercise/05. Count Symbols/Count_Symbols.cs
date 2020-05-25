using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Count_Symbols
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < sentence.Length; i++)
            {
                if (!dict.ContainsKey(sentence[i]))
                {
                    dict[sentence[i]] = 0;
                }
                dict[sentence[i]]++;
            }

            foreach (var letter in dict.OrderBy(o => o.Key))
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}
