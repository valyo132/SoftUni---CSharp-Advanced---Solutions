using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> table = new Dictionary<string, int>()
            {
                ["Gladius"] = 70,
                ["Shamshir"] = 80,
                ["Katana"] = 90,
                ["Sabre"] = 110,
                ["Broadsword"] = 150,
            };

            int[] stealInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> steal = new Queue<int>(stealInput);

            int[] carbonInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> carbon = new Stack<int>(carbonInput);

            var result = new Dictionary<string, int>();
            int craftedSwords = 0;

            while (steal.Count > 0 && carbon.Count > 0)
            {
                int currSteal = steal.Dequeue();
                int currCarbon = carbon.Pop();

                if (table.Any(x => x.Value == currSteal + currCarbon))
                {
                    var sword = table.First(x => x.Value == currSteal + currCarbon).Key;
                    craftedSwords++;

                    if (!result.ContainsKey(sword))
                        result[sword] = 1;
                    else
                        result[sword]++;
                }
                else
                {
                    carbon.Push(currCarbon + 5);
                }
            }

            if (result.Any())
                Console.WriteLine($"You have forged {craftedSwords} swords.");
            else
                Console.WriteLine("You did not have enough resources to forge a sword.");

            if (steal.Count <= 0)
                Console.WriteLine("Steel left: none");
            else
                Console.WriteLine($"Steel left: {string.Join(", ", steal)}");

            if (carbon.Count <= 0)
                Console.WriteLine("Carbon left: none");
            else
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");

            foreach (var item in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
