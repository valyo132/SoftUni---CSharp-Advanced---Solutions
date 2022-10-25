using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sets = new List<int>();

            int[] hatInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> hats = new Stack<int>(hatInput);

            int[] scarfInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> scarfs = new Queue<int>(scarfInput);

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currHat = hats.Pop();
                int currScarf = scarfs.Dequeue();

                if (currHat > currScarf)
                {
                    int value = currHat + currScarf;
                    sets.Add(value);
                }
                else if (currHat < currScarf)
                {
                    while (hats.Count > 0)
                    {
                        currHat = hats.Pop();
                        if (currHat > currScarf)
                        {
                            int value = currHat + currScarf;
                            sets.Add(value);
                            break;
                        }
                        else if (currHat == currScarf)
                        {
                            hats.Push(currHat + 1);
                            break;
                        }
                    }
                }
                else
                {
                    hats.Push(currHat + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.OrderByDescending(x => x).FirstOrDefault()}"); //
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
