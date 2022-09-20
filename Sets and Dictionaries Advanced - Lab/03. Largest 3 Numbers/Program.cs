using System;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] largestNumbers = numbers.OrderByDescending(x => x).ToArray();

            for (int i = 0; i < largestNumbers.Length; i++)
            {
                if (i == 3)
                {
                    return;
                }

                Console.Write(largestNumbers[i] + " ");
            }
        }
    }
}
