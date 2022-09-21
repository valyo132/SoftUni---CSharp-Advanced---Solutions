using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>(sizes[0]);
            HashSet<int> secondSet = new HashSet<int>(sizes[1]);

            List<int> allNumbers = new List<int>();

            for (int i = 0; i < sizes[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());

                firstSet.Add(num);
                allNumbers.Add(num);
            }

            for (int i = 0; i < sizes[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
                allNumbers.Add(num);
            }

            HashSet<int> numbersToPrint = new HashSet<int>();

            foreach (var num in allNumbers)
            {
                if (firstSet.Contains(num) && secondSet.Contains(num))
                {
                    numbersToPrint.Add(num);
                }
            }

            Console.WriteLine(String.Join(" ", numbersToPrint));
        }
    }
}
