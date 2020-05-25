using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Product_Shop
    {
        static void Main(string[] args)
        {
            // shops => product => price
            var shops = new Dictionary<string, Dictionary<string, double>>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Revision")
                {
                    break;
                }
                var tokens = line
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string shop = tokens[0];
                var product = tokens[1];
                var price = double.Parse(tokens[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop].Add(product, 0);
                }
                shops[shop][product] = price;
            }

            foreach (var kvp in shops.OrderBy(x => x.Key))
            {
                var shop = kvp.Key;
                var products = kvp.Value;
                Console.WriteLine($"{shop}->");
                foreach (var productKvp in products)
                {
                    Console.WriteLine($"Product: {productKvp.Key}, Price: {productKvp.Value}");
                }
            }
        }
    }
}
