using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfQueries = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < countOfQueries; i++)
            {
                int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();


                switch (query[0])
                {
                    case 1:
                        int elementToPush = query[1];

                        numbers.Push(elementToPush);
                        break;
                    case 2:
                        if (numbers.Count > 0)
                        {
                            numbers.Pop();
                        }
                        break;
                    case 3:
                        if (numbers.Count == 0)
                        {
                            continue;
                        }

                        int max = int.MinValue;

                        foreach (var num in numbers)
                        {
                            if (num > max)
                            {
                                max = num;
                            }
                        }

                        Console.WriteLine(max);
                        break;
                    case 4:
                        if (numbers.Count == 0)
                        {
                            continue;
                        }

                        int min = int.MaxValue;

                        foreach (var num in numbers)
                        {
                            if (num < min)
                            {
                                min = num;
                            }
                        }

                        Console.WriteLine(min);
                        break;
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
