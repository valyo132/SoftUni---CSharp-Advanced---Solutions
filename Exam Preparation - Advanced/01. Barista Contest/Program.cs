using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> coffieMachiene = new Dictionary<string, int>()
            {
                ["Cortado"] = 50,
                ["Espresso"] = 75,
                ["Capuccino"] = 100,
                ["Americano"] = 150,
                ["Latte"] = 200,
            };

            Dictionary<string, int> resultDictionary = new Dictionary<string, int>();

            int[] inputCoffie = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> coffieQueue = new Queue<int>(inputCoffie);

            int[] inputMilk = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> milkStask = new Stack<int>(inputMilk);

            while (coffieQueue.Count > 0 && milkStask.Count > 0)
            {
                int currCoffie = coffieQueue.Peek();
                int currMilk = milkStask.Peek();

                int value = currCoffie + currMilk;

                if (coffieMachiene.Any(x => x.Value == value))
                {
                    string drinkToAdd = coffieMachiene.First(x => x.Value == value).Key;

                    if (!resultDictionary.ContainsKey(drinkToAdd))
                        resultDictionary[drinkToAdd] = 1;
                    else
                        resultDictionary[drinkToAdd]++;

                    coffieQueue.Dequeue();
                    milkStask.Pop();
                }
                else
                {
                    coffieQueue.Dequeue();

                    milkStask.Pop();
                    milkStask.Push(currMilk - 5);
                }
            }

            if (milkStask.Count == 0 && coffieQueue.Count == 0)
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            else
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");

            if (coffieQueue.Count != 0)
                Console.WriteLine($"Coffee left: {string.Join(", ", coffieQueue)}");
            else
                Console.WriteLine("Coffee left: none");

            if (milkStask.Count != 0)
                Console.WriteLine($"Milk left: {string.Join(", ", milkStask)}");
            else
                Console.WriteLine("Milk left: none");

            foreach (var item in resultDictionary.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
