using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbersAndCounts = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (numbersAndCounts.ContainsKey(number))
                {
                    numbersAndCounts[number]++;
                }
                else
                {
                    numbersAndCounts[number] = 1;
                }
            }

            int numberToPrint = numbersAndCounts.First(x => x.Value % 2 == 0).Key;

            Console.WriteLine(numberToPrint);
        }
    }
}
