using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] capacityInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> capacity = new Queue<int>(capacityInput);

            int[] plateInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> plates = new Stack<int>(plateInput);

            int wastedFood = 0;

            while (capacity.Count > 0 && plates.Count > 0)
            {
                int currGuest = capacity.Dequeue();
                int currPlate = plates.Pop();

                int value = currPlate - currGuest;

                while (value < 0)
                {
                    value = Math.Abs(value);
                    value = plates.Pop() - value;
                }

                if (value > 0)
                {
                    wastedFood += value;
                }
            }

            if (capacity.Count > 0)
                Console.WriteLine($"Guests: {string.Join(" ", capacity)}");
            else
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
