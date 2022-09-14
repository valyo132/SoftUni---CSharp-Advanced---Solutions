using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> evenNumbers = new Queue<int>();

            foreach (var num in numbers)
            {
                if (num % 2 == 0)
                {
                    evenNumbers.Enqueue(num);
                }
            }

            Console.WriteLine(String.Join(", ", evenNumbers));
        }
    }
}
