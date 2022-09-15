using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> allNumbers = new Queue<int>();

            int countOfElements = inputNumbers[0];
            int countToPop = inputNumbers[1];
            int numberToLookFor = inputNumbers[2];

            int[] numbersInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var num in numbersInput)
            {
                allNumbers.Enqueue(num);
            }

            for (int i = 0; i < countToPop; i++)
            {
                allNumbers.Dequeue();
            }

            if (allNumbers.Contains(numberToLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (allNumbers.Count > 0)
                {
                    int smallestNumber = int.MaxValue;

                    foreach (var number in allNumbers)
                    {
                        if (number < smallestNumber)
                        {
                            smallestNumber = number;
                        }
                    }

                    Console.WriteLine(smallestNumber);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
