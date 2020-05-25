using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Average_Student_Grades
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var marks = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < lines; i++)
            {
                var markParts = Console.ReadLine().Split();
                var name = markParts[0];
                var mark = decimal.Parse(markParts[1]);
                if (!marks.ContainsKey(name))
                {
                    marks[name] = new List<decimal>();
                }

                marks[name].Add(mark);
            }

            foreach (var kvp in marks)
            {
                string name = kvp.Key;
                List<decimal> currentMarks = kvp.Value;
                decimal average = currentMarks.Average();

                Console.Write($"{name} -> ");
                foreach (var mark in currentMarks)
                {
                    Console.Write($"{mark:f2} ");
                }

                Console.WriteLine($"(avg: {average:f2})");

            }
        }
    }
}
