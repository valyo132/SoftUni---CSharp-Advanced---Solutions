using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            Predicate<int> IsEven = x => x % 2 == 0;

            var resultNumbers = new List<int>();

            for (int i = numbers[0]; i <= numbers[1]; i++)
                resultNumbers.Add(i);

            if (command == "odd")
                resultNumbers = resultNumbers.Where(x => !IsEven(x)).ToList();
            else
                resultNumbers = resultNumbers.Where(x => IsEven(x)).ToList();

            Console.WriteLine(String.Join(" ", resultNumbers));
        }
    }
}
