using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rosesInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> roses = new Queue<int>(rosesInput);

            int[] liliesInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> lilies = new Stack<int>(liliesInput);

            int countOfWreaths = 0;
            int remainingFlowers = 0;

            while (roses.Count > 0 && lilies.Count > 0)
            {
                int currRoses = roses.Dequeue();
                int currlilies = lilies.Pop();

                int value = currRoses + currlilies;

                while (true)
                {
                    if (value == 15)
                    {
                        countOfWreaths++;
                        break;
                    }
                    else if (value < 15)
                    {
                        remainingFlowers += value;
                        break;
                    }
                    else
                    {
                        value -= 2;
                    }
                }
            }

            int wreathsToAdd = remainingFlowers / 15;
            countOfWreaths += wreathsToAdd;

            if (countOfWreaths >= 5)
                Console.WriteLine($"You made it, you are going to the competition with {countOfWreaths} wreaths!");
            else
                Console.WriteLine($"You didn't make it, you need {5 - countOfWreaths} wreaths more!");
        }
    }
}
