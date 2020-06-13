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
                if (currentMale % 25 == 0)
                {
                    males.Pop();
                    if (males.Count > 0)
                    {
                        males.Pop();
                    }
                    continue;
                }
                if (currentFemale % 25 == 0)
                {
                    females.Dequeue();
                    if (females.Count > 0)
                    {
                        females.Dequeue();
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
            sb.AppendLine(maleList.Count > 0 ? $"Males left: {string.Join(", ", maleList)}" :  "Males left: none");
            sb.AppendLine(femaleList.Count > 0 ? $"Females left: {string.Join(", ", femaleList)}" : "Females left: none");
            return sb.ToString();
        }
    }
}