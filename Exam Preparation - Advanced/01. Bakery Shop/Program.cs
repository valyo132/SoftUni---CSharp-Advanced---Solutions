using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double, double> getRatio = (currWater, currFlour) =>
            {
                double delitel = currWater + currFlour;
                double ratio = (currWater * 100) / delitel;

                return ratio;
            };

            Dictionary<string, int> products = new Dictionary<string, int>()
            {
                ["Croissant"] = 50,
                ["Muffin"] = 40,
                ["Baguette"] = 30,
                ["Bagel"] = 20,
            };

            double[] waterInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            Queue<double> water = new Queue<double>(waterInput);

            double[] flourInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            Stack<double> flour = new Stack<double>(flourInput);

            Dictionary<string, int> result = new Dictionary<string, int>();

            while (water.Count > 0 && flour.Count > 0)
            {
                double currWater = water.Peek();
                double currFlour = flour.Peek();

                double ratio = getRatio(currWater, currFlour);

                if (products.Any(x => x.Value == ratio))
                {
                    var product = products.First(x => x.Value == ratio).Key;

                    if (!result.ContainsKey(product))
                        result[product] = 1;
                    else
                        result[product]++;

                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    double flourToAdd = Math.Abs(currWater - currFlour);
                    water.Dequeue();
                    flour.Pop();
                    flour.Push(flourToAdd);

                    if (!result.ContainsKey("Croissant"))
                        result["Croissant"] = 1;
                    else
                        result["Croissant"]++;
                }
            }

            foreach (var item in result.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (water.Count == 0)
                Console.WriteLine("Water left: None");
            else
                Console.WriteLine($"Water left: {String.Join(", ", water)}");

            if (flour.Count == 0)
                Console.WriteLine("Flour left: None");
            else
                Console.WriteLine($"Flour left: {String.Join(", ", flour)}");
        }
    }
}
