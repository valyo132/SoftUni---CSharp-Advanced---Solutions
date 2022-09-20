using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] inputNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var dictionary = new Dictionary<double, int>();

            foreach (var item in inputNumbers)
            {
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item]++;
                }
                else
                {
                    dictionary[item] = 1;
                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
