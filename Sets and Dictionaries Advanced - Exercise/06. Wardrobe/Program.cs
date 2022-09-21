using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] cloths = input[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();

                    foreach (var cloth in cloths)
                    {
                        if (!wardrobe[color].ContainsKey(cloth))
                        {
                            wardrobe[color][cloth] = 1;
                        }
                        else
                        {
                            wardrobe[color][cloth]++;
                        }
                    }
                }
                else
                {
                    foreach (var cloth in cloths)
                    {
                        if (!wardrobe[color].ContainsKey(cloth))
                        {
                            wardrobe[color][cloth] = 1;
                        }
                        else
                        {
                            wardrobe[color][cloth]++;
                        }
                    }
                }
            }

            string[] wantedClothing = Console.ReadLine().Split(" ");
            string wantedColor = wantedClothing[0];
            string wantetCloth = wantedClothing[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes: ");

                foreach (var cloth in color.Value)
                {
                    Console.Write($"* {cloth.Key} - {cloth.Value} ");
                    if (wantedColor == color.Key && wantetCloth == cloth.Key)
                    {
                        Console.Write("(found!)");
                    }

                    Console.WriteLine();
                }

            }
        }
    }
}
