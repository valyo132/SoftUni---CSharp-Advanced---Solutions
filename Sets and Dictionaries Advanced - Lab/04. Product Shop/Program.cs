using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Revision")
                {
                    break;
                }

                string shop = command[0];
                string product = command[1];
                double price = double.Parse(command[2]);

                if (!result.ContainsKey(shop))
                {
                    result.Add(shop, new Dictionary<string, double>());
                    result[shop].Add(product, price);
                }
                else
                {
                    result[shop].Add(product, price);
                }
            }

            var orderedShops = result.OrderBy(x => x.Key).ToDictionary(k => k.Key, p => p.Value);

            foreach (var shop in orderedShops)
            {
                Console.WriteLine(shop.Key + "->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
