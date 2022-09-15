using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> allNumbers = new Stack<int>();

            int countOfElements = inputNumbers[0];
            int countToPop = inputNumbers[1];
            int numberToLookFor = inputNumbers[2];

            int[] numbersInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var num in numbersInput)
            {
                allNumbers.Push(num);
            }

            for (int i = 0; i < countToPop; i++)
            {
                allNumbers.Pop();
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
