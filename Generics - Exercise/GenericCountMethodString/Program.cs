using System;
using System.Collections.Generic;

namespace GenericCountMethodString
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

            string itemToCompare = Console.ReadLine();
            Console.WriteLine(box.Count(items, itemToCompare));
        }
    }
}
