using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> allNumbers = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(allNumbers.Count);
            Console.WriteLine(allNumbers.Sum());
        }
    }
}
