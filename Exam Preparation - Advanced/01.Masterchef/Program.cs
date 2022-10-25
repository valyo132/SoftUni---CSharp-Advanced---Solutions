using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> table = new Dictionary<string, int>()
            {
                ["Dipping sauce"] = 150,
                ["Green salad"] = 250,
                ["Chocolate cake"] = 300,
                ["Lobster"] = 400,
            };

            int[] ingredientsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> ingredients = new Queue<int>(ingredientsInput);

            int[] freshnessInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> freshness = new Stack<int>(freshnessInput);

            var result = new Dictionary<string, int>();

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int currIngredient = ingredients.Dequeue();
                if (currIngredient == 0) continue;

                int currFreshness = freshness.Pop();

                int value = currIngredient * currFreshness;

                if (table.Any(x => x.Value == value))
                {
                    var dish = table.First(x => x.Value == value).Key;

                    if (!result.ContainsKey(dish))
                        result[dish] = 1;
                    else
                        result[dish]++;
                }
                else
                {
                    ingredients.Enqueue(currIngredient + 5);
                }
            }

            if (result.Count >= 4)
                Console.WriteLine($"Applause! The judges are fascinated by your dishes!");
            else
                Console.WriteLine("You were voted off. Better luck next year.");

            if (ingredients.Any())
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");

            foreach (var item in result.Where(x => x.Value >= 1).OrderBy(x => x.Key))
            {
                Console.WriteLine($"# {item.Key} --> {item.Value}");
            }
        }
    }
}
