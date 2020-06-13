using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatingApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] malesArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int[] feMalesArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            Stack<int> males = new Stack<int>(malesArr);
            Queue<int> females = new Queue<int>(feMalesArr);

            int matchesCount = 0;

            while (males.Any() && females.Any())
            {
                int currentMale = males.Peek();
                int currentFemale = females.Peek();
                if (currentMale <= 0)
                {
                    males.Pop();
                    continue;
                }
                if (currentFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }
                if (currentFemale % 25 == 0)
                {
                    if (females.Count > 1)
                    {
                        females.Dequeue();
                        females.Dequeue();
                    }
                    else
                    {
                        females.Dequeue();
                    }
                    continue;
                }
                if (currentMale % 25 == 0)
                {
                    if (males.Count > 1)
                    {
                        males.Pop();
                        males.Pop();
                    }
                    else
                    {
                        males.Pop();
                    }
                    continue;
                }
                if (currentMale == currentFemale)
                {
                    matchesCount++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    females.Dequeue();
                    males.Push(males.Pop() - 2);
                }
            }
            Console.WriteLine(Print(matchesCount, males, females));
        }
        private static string Print(int matchesCount, Stack<int> males, Queue<int> females)
        {
            var maleList = males.ToList();
            var femaleList = females.ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Matches: {matchesCount}");
            sb.AppendLine(maleList.Count == 0 ? "Males left: none" : $"Males left: {string.Join(", ", maleList)}");
            sb.AppendLine(femaleList.Count == 0 ? "Females left: none" : $"Females left: {string.Join(", ", femaleList)}");
            return sb.ToString();
        }
    }
}