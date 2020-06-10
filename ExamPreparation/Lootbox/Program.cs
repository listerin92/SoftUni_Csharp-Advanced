using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] firstLootboxArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondLootboxArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> firstLootbox = new Queue<int>(firstLootboxArr);
            Stack<int> secondLootbox = new Stack<int>(secondLootboxArr);

            int claimedItemsSum = 0;
            while (true)
            {
                if (firstLootbox.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }

                if (secondLootbox.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }
                //even-четно num%2 == 0
                if ((firstLootbox.Peek() + secondLootbox.Peek()) % 2 == 0)
                {
                    claimedItemsSum += firstLootbox.Dequeue() + secondLootbox.Pop();
                }
                else
                {
                    firstLootbox.Enqueue(secondLootbox.Pop());

                }

                
            }

            Console.WriteLine(claimedItemsSum >= 100
                ? $"Your loot was epic! Value: {claimedItemsSum}"
                : $"Your loot was poor... Value: {claimedItemsSum}");
        }
    }
}