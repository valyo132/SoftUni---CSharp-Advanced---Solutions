using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] miligramsInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> miligrams = new Stack<int>(miligramsInput);

            int[] energyInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> energy = new Queue<int>(energyInput);

            int stamatCafeeine = 0;

            while (miligrams.Count > 0 && energy.Count > 0)
            {
                int currMiligrams = miligrams.Pop();
                int currEneregy = energy.Dequeue();

                int value = currMiligrams * currEneregy;

                if (stamatCafeeine + value <= 300) // <
                {
                    stamatCafeeine += value;
                }
                else
                {
                    energy.Enqueue(currEneregy);
                    if (stamatCafeeine - 30 < 0)
                    {
                        stamatCafeeine = 0;
                    }
                    else
                    {
                        stamatCafeeine -= 30;

                    }
                }
            }

            if (energy.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energy)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {stamatCafeeine} mg caffeine.");
        }
    }
}
