using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var locationsAndNeededTiles = new Dictionary<string, int>()
            {
                ["Sink"] = 40,
                ["Oven"] = 50,
                ["Countertop"] = 60,
                ["Wall"] = 70,
            };

            var resultDictionary = new Dictionary<string, int>();

            int[] whiteTiles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> white = new Stack<int>(whiteTiles);

            int[] greyTiles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> grey = new Queue<int>(greyTiles);

            while (white.Count > 0 && grey.Count > 0)
            {
                int currWhiteItem = white.Peek();
                int currGreyItem = grey.Peek();

                if (currGreyItem == currWhiteItem)
                {
                    int newTileValue = currGreyItem + currWhiteItem;

                    if (locationsAndNeededTiles.Any(x => x.Value == newTileValue))
                    {
                        string location = locationsAndNeededTiles.First(x => x.Value == newTileValue).Key.ToString();

                        if (!resultDictionary.ContainsKey(location))
                            resultDictionary[location] = 1;
                        else
                            resultDictionary[location]++;

                        grey.Dequeue();
                        white.Pop();
                    }
                    else
                    {
                        if (!resultDictionary.ContainsKey("Floor"))
                            resultDictionary["Floor"] = 1;
                        else
                            resultDictionary["Floor"]++;

                        grey.Dequeue();
                        white.Pop();
                    }
                }
                else
                {
                    int itemToDecrece = white.Pop();
                    white.Push(itemToDecrece / 2);

                    int itemToRelocate = grey.Dequeue();
                    grey.Enqueue(itemToRelocate);
                }
            }

            PrintResult(resultDictionary, white, grey);
        }

        private static void PrintResult(Dictionary<string, int> resultDictionary, Stack<int> white, Queue<int> grey)
        {
            if (white.Count == 0)
                Console.WriteLine("White tiles left: none");
            else
                Console.WriteLine("White tiles left: " + String.Join(", ", white));

            if (grey.Count == 0)
                Console.WriteLine("Grey tiles left: none");
            else
                Console.WriteLine("Grey tiles left: " + String.Join(", ", grey));

            foreach (var item in resultDictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
