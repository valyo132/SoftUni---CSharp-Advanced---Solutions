using System;
using System.Collections.Generic;

namespace GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            var items = new List<int>();

            int number = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int i = 0; i < number; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box = new Box<int>(input);
                items.Add(input);
            }

            string[] indexes = Console.ReadLine().Split();
            int firstIndex = int.Parse(indexes[0]);
            int secondIndex = int.Parse(indexes[1]);

            items = box.Swap(items, firstIndex, secondIndex);

            foreach (var item in items)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
    }
}
