using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boxOfMaterialsArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] magicLevelArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> boxOfMaterials = new Stack<int>(boxOfMaterialsArr);
            Queue<int> magicLevel = new Queue<int>(magicLevelArr);
            var presents = new Dictionary<string, int>
            {
                { "Doll", 0 },
                { "Wooden train", 0 },
                { "Teddy bear", 0 },
                { "Bicycle", 0 }
            };
            while (boxOfMaterials.Any() && magicLevel.Any())
            {
                int currentBoxOfMaterial = boxOfMaterials.Peek();
                int currentMagicLevel = magicLevel.Peek();
                var boxOfMaterial = currentBoxOfMaterial * currentMagicLevel;

                if (boxOfMaterial == 0)
                {
                    if (currentBoxOfMaterial == 0)
                    {
                        boxOfMaterials.Pop();
                    }
                    if (currentMagicLevel == 0)
                    {
                        magicLevel.Dequeue();
                    }
                    continue;
                }

                if (boxOfMaterial == 150)
                {
                    presents["Doll"]++;
                    boxOfMaterials.Pop();
                    magicLevel.Dequeue();
                    continue;
                }
                if (boxOfMaterial == 250)
                {
                    presents["Wooden train"]++;
                    boxOfMaterials.Pop();
                    magicLevel.Dequeue();
                    continue;
                }
                if (boxOfMaterial == 300)
                {
                    presents["Teddy bear"]++;
                    boxOfMaterials.Pop();
                    magicLevel.Dequeue();
                    continue;
                }
                if (boxOfMaterial == 400)
                {
                    presents["Bicycle"]++;
                    boxOfMaterials.Pop();
                    magicLevel.Dequeue();
                    continue;
                }
                if (boxOfMaterial < 0)
                {
                    int temp = currentBoxOfMaterial + currentMagicLevel;
                    boxOfMaterials.Pop();
                    magicLevel.Dequeue();
                    boxOfMaterials.Push(temp);
                    continue;
                }
                magicLevel.Dequeue();
                boxOfMaterials.Push(boxOfMaterials.Pop() + 15);
            }

            var boxList = boxOfMaterials.ToList();
            var magicList = magicLevel.ToList();
            if ((presents.Any(x => (x.Key == "Doll" && x.Value > 0)) &&
                presents.Any(x => (x.Key == "Wooden train" && x.Value > 0))) ||
                presents.Any(x => (x.Key == "Teddy bear" && x.Value > 0)) &&
                presents.Any(x => (x.Key == "Bicycle" && x.Value > 0)))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");

            }
            if (boxList.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", boxList)}");
            }
            if (magicList.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicList)}");
            }

            foreach (var present in presents.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                Console.WriteLine($"{present.Key}: {present.Value}");
            }

        }
    }
}
