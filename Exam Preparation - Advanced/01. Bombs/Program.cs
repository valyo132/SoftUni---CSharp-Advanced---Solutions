using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var table = new Dictionary<string, int>()
            {
                ["Datura Bombs"] = 40,
                ["Cherry Bombs"] = 60,
                ["Smoke Decoy Bombs"] = 120,
            };

            int[] bombEffectsInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> bombEffects = new Queue<int>(bombEffectsInput);

            int[] casingInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> casings = new Stack<int>(casingInput);

            var result = new Dictionary<string, int>()
            {
                ["Datura Bombs"] = 0,
                ["Cherry Bombs"] = 0,
                ["Smoke Decoy Bombs"] = 0,
            };

            while (bombEffects.Count > 0 && casings.Count > 0)
            {
                int currBombEffect = bombEffects.Peek();
                int currCase = casings.Pop();

                int value = currBombEffect + currCase;

                if (table.Any(x => x.Value == value))
                {
                    var key = table.First(x => x.Value == value).Key;
                    result[key]++;

                    bombEffects.Dequeue();
                }
                else
                {
                    casings.Push(currCase - 5);
                }

                if (result.All(x => x.Value >= 3))
                    break;
            }

            if (result.All(x => x.Value >= 3))
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            else
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");

            if (bombEffects.Count <= 0)
                Console.WriteLine("Bomb Effects: empty");
            else
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");

            if (casings.Count <= 0)
                Console.WriteLine("Bomb Casings: empty");
            else
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");

            foreach (var item in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
