using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] boxInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> firstBox = new Queue<int>(boxInput);

            boxInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> secondBox = new Stack<int>(boxInput);

            int result = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int item1 = firstBox.Peek();
                int item2 = secondBox.Peek();

                int value = item1 + item2;

                if (value % 2 == 0)
                {
                    result += value;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                    firstBox.Enqueue(secondBox.Pop());
            }

            if (firstBox.Count <= 0)
                Console.WriteLine("First lootbox is empty");
            else if (secondBox.Count <= 0)
                Console.WriteLine("Second lootbox is empty");

            if (result >= 100)
                Console.WriteLine($"Your loot was epic! Value: {result}");
            else
                Console.WriteLine($"Your loot was poor... Value: {result}");
        }
    }
}
