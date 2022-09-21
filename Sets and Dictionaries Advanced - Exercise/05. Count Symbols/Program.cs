using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> table = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (table.ContainsKey(input[i]))
                {
                    table[input[i]]++;
                }
                else
                {
                    table.Add(input[i], 1);
                }
            }

            foreach (var ch in table)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
