using System;
using System.Collections.Generic;

namespace GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            var items = new List<string>();

            int number = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                box = new Box<string>(input);
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
