using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubParty_New
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxCapacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string[] reservation = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Stack<string> elements = new Stack<string>(reservation);
            Queue<string> halls = new Queue<string>();
            List<int> allGroups = new List<int>();
            int currentCapacity = 0;

            while (elements.Count > 0)
            {
                string currentElement = elements.Pop();
                bool isNumber = int.TryParse(currentElement, out int parsedNumber);
                if (!isNumber)
                {
                    halls.Enqueue(currentElement);
                }
                else
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }
                    if (currentCapacity + parsedNumber > maxCapacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", allGroups)}");
                        allGroups.Clear();
                        currentCapacity = 0;
                    }

                    if (halls.Count > 0)
                    {
                        allGroups.Add(parsedNumber);
                        currentCapacity += parsedNumber;
                    }
                }

            }
        }
    }
}
