using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> nonDivisible = (num, digit)
                => num % digit != 0;

            Func<List<int>, int, List<int>> fillTheList = (numbers, digit)
                => numbers.Where(x => nonDivisible(x, digit)).Reverse().ToList();

            Action<List<int>> printNumbers = numbers
                => Console.WriteLine(String.Join(" ", numbers));

            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int digit = int.Parse(Console.ReadLine());

            printNumbers(fillTheList(numbers, digit));
        }

    }
}
