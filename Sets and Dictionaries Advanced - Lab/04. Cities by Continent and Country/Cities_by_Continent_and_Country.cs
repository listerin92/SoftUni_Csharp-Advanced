using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cities_by_Continent_and_Country
{
    class Cities_by_Continent_and_Country
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var ccc = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < lines; i++)
            {
                var tokens = Console.ReadLine().Split(' ').ToArray();
                var continent = tokens[0];
                var countries = tokens[1];
                var cities = tokens[2];

                if (!ccc.ContainsKey(continent))
                {
                    ccc.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!ccc[continent].ContainsKey(countries))
                {
                    ccc[continent].Add(countries, new List<string>());
                }
                ccc[continent][countries].Add(cities);

            }
            foreach (var continent in ccc)
            {
                var countries = continent.Value;
                Console.WriteLine($"{continent.Key}:");

                foreach (var countrie in countries)
                {
                    Console.Write($"  {countrie.Key} -> ");
                    Console.Write(string.Join(", ", countrie.Value));
                    Console.WriteLine();
                }
            }
        }
    }
}
