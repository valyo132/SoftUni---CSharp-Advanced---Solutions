using System;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 1; i <= endOfRange; i++)
            {
                if (cheker(i, dividers))
                    Console.Write(i + " ");
            }
        }

        public static Func<int, int[], bool> cheker = (i, dividers) =>
        {
            var validNumbers = dividers.Where(divider => i % divider == 0).ToList();

            return validNumbers.Count == dividers.Length ? true : false;
        };
    }
}
