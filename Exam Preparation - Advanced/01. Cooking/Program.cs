using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> table = new Dictionary<string, int>()
            {
                ["Bread"] = 25,
                ["Cake"] = 50,
                ["Pastry"] = 75,
                ["Fruit Pie"] = 100,
            };

            int[] liquidInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> liquids = new Queue<int>(liquidInput);

            int[] ingredientsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> ingredients = new Stack<int>(ingredientsInput);

            var result = new Dictionary<string, int>()
            {
                ["Bread"] = 0,
                ["Cake"] = 0,
                ["Pastry"] = 0,
                ["Fruit Pie"] = 0,
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currLiquid = liquids.Dequeue();
                int currIngredient = ingredients.Pop();

                int value = currLiquid + currIngredient;

                if (table.Any(x => x.Value == value))
                {
                    var dish = table.FirstOrDefault(x => x.Value == value).Key;

                    if (result.ContainsKey(dish))
                        result[dish]++;
                }
                else
                {
                    ingredients.Push(currIngredient + 3);
                }
            }

            if (result.All(x => x.Value > 0))
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            else
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");

            if (liquids.Count <= 0)
                Console.WriteLine("Liquids left: none");
            else
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");

            if (ingredients.Count <= 0)
                Console.WriteLine("Ingredients left: none");
            else
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");

            foreach (var item in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
