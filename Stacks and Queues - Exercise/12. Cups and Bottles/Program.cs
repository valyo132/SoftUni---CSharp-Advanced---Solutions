using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottleWithWater = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queueCapacity = new Queue<int>(cupsCapacity);
            var stackBottles = new Stack<int>(bottleWithWater);

            int wastedWater = 0;

            while (stackBottles.Count > 0)
            {
                int water = stackBottles.Pop();
                int cup = queueCapacity.Peek();

                if (water - cup >= 0)
                {
                    wastedWater += water - cup;

                    queueCapacity.Dequeue();
                }
                else
                {
                    cup -= water;

                    while (cup > 0)
                    {
                        water = stackBottles.Pop();

                        if (water - cup >= 0)
                        {
                            wastedWater += water - cup;

                            queueCapacity.Dequeue();

                            cup = 0;
                        }
                        else
                        {
                            cup -= water;
                        }
                    }
                }

                if (queueCapacity.Count == 0)
                {
                    Console.Write($"Bottles: ");
                    foreach (var bottle in stackBottles)
                    {
                        Console.Write($"{bottle} ");
                    }

                    Console.WriteLine();

                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    return;
                }
            }

            Console.Write($"Cups: ");

            foreach (var cup in queueCapacity)
            {
                Console.Write($"{cup} ");
            }

            Console.WriteLine();

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
