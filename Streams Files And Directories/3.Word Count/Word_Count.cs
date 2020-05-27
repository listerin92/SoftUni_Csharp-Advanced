using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.Word_Count
{
    class Word_Count
    {
        static void Main(string[] args)
        {
            using var words = new StreamReader("words.txt");
            using var input = new StreamReader("Input.txt");
            using var output = new StreamWriter("Output.txt");

            string[] tokens = words.ReadLine().Split(' ').ToArray();
            Dictionary<string, int> count = new Dictionary<string, int>();


            var line = input.ReadToEnd();

            foreach (var word in tokens)
            {
                var pattern = $@"\b{word}\b";
                var match = Regex.Matches(line.ToLower(), pattern);
                if (!count.ContainsKey(word))
                {
                    count[word] = 0;
                }
                count[word] += match.Count;
            }

            foreach (var word in count.OrderByDescending(o=>o.Value))
            {
                output.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
