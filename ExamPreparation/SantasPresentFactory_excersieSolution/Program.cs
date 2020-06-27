using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasPresentFactory_exerciseSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lineOne = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] lineTwo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Stack<int> materialsForCrafting = new Stack<int>(lineOne);
            Queue<int> magicLevelValues = new Queue<int>(lineTwo);
            var presentsMagicLevel = new Dictionary<int, string>
            {
                {150, "Doll"},
                {250, "Wooden train"},
                {300, "Teddy bear"},
                {400, "Bicycle"}
            };
            var presentsMade = new SortedDictionary<string, int>();
            while (materialsForCrafting.Count > 0 && magicLevelValues.Count > 0)
            {
                var magicLevel = materialsForCrafting.Peek() *
                                 magicLevelValues.Peek();
                if (presentsMagicLevel.ContainsKey(magicLevel))
                {
                    if (!presentsMade.ContainsKey(presentsMagicLevel[magicLevel]))
                    {
                        presentsMade.Add(presentsMagicLevel[magicLevel], 0);
                    }

                    presentsMade[presentsMagicLevel[magicLevel]]++;
                    materialsForCrafting.Pop();
                    magicLevelValues.Dequeue();
                }
                else
                {
                    if (magicLevel < 0)
                    {
                        int sum = materialsForCrafting.Peek() + magicLevelValues.Peek();
                        materialsForCrafting.Pop();
                        magicLevelValues.Dequeue();
                        materialsForCrafting.Push(sum);
                    }
                    else if (magicLevel > 0)
                    {
                        magicLevelValues.Dequeue();
                        materialsForCrafting.Push(materialsForCrafting.Pop() + 15);
                    }
                    else if (magicLevel == 0) // it always true, but stays only for checking
                    {
                        if (materialsForCrafting.Peek() == 0)
                        {
                            materialsForCrafting.Pop();
                        }

                        if (magicLevelValues.Peek() == 0)
                        {
                            magicLevelValues.Dequeue();
                        }
                    }
                }
            }

            if ((presentsMade.ContainsKey("Doll") && presentsMade.ContainsKey("Wooden train"))
                || (presentsMade.ContainsKey("Teddy bear") && presentsMade.ContainsKey("Bicycle")))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materialsForCrafting.Count > 0)
            {
                Console.WriteLine("Materials left: " + string.Join(", ", materialsForCrafting));
            }
            if (magicLevelValues.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicLevelValues)}");
            }

            foreach (var present in presentsMade)
            {
                Console.WriteLine($"{present.Key}: {present.Value}");
            }
        }
    }
}