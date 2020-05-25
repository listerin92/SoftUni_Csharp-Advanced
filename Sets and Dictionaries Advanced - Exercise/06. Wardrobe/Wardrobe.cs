using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split(" -> ").ToArray();

                string color = tokens[0];
                var clothes = tokens[1].Split(',').ToList();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }
                for (int j = 0; j < clothes.Count; j++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[j]))
                    {
                        wardrobe[color][clothes[j]] = 0;
                    }
                    wardrobe[color][clothes[j]]++;
                }
            }

            string[] toFind = Console.ReadLine().Split().ToArray();

            Print(wardrobe, toFind);
        }

        private static void Print(Dictionary<string, Dictionary<string, int>> wardrobe, string[] toFind)
        {
            string colorToFind = toFind[0];
            string dressToFind = toFind[1];
            bool colorFound = false;
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                if (colorToFind == color.Key)
                {
                    colorFound = true;
                }
                foreach (var cloth in color.Value)
                {
                    if (colorFound && (dressToFind == cloth.Key))
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                        colorFound = false;
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
