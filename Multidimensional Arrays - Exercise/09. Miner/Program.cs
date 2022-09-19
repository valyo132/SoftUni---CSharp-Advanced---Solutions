using System;
using System.Linq;

namespace _09._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            string[] moves = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int currRowIndex = 0;
            int currColIndex = 0;

            int totalCoalToCollect = 0;

            for (int row = 0; row < size; row++)
            {
                char[] rowElements = Console.ReadLine().Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowElements[col];

                    if (matrix[row, col] == 's')
                    {
                        currRowIndex = row;
                        currColIndex = col;
                    }

                    if (matrix[row, col] == 'c')
                    {
                        totalCoalToCollect++;
                    }
                }
            }

            int collectedCoal = 0;

            foreach (var move in moves)
            {
                switch (move)
                {
                    case "up":
                        if (currRowIndex - 1 >= 0 && currRowIndex - 1 < size)
                        {
                            currRowIndex = currRowIndex - 1;

                            if (matrix[currRowIndex, currColIndex] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRowIndex}, {currColIndex})");
                                return;
                            }
                            else if (matrix[currRowIndex, currColIndex] == 'c')
                            {
                                matrix[currRowIndex, currColIndex] = '*';

                                collectedCoal++;

                                if (collectedCoal == totalCoalToCollect)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRowIndex}, {currColIndex})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "right":
                        if (currColIndex + 1 >= 0 && currColIndex + 1 < size)
                        {
                            currColIndex = currColIndex + 1;

                            if (matrix[currRowIndex, currColIndex] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRowIndex}, {currColIndex})");
                                return;
                            }
                            else if (matrix[currRowIndex, currColIndex] == 'c')
                            {
                                matrix[currRowIndex, currColIndex] = '*';

                                collectedCoal++;

                                if (collectedCoal == totalCoalToCollect)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRowIndex}, {currColIndex})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "left":
                        if (currColIndex - 1 >= 0 && currColIndex - 1 < size)
                        {
                            currColIndex = currColIndex - 1;

                            if (matrix[currRowIndex, currColIndex] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRowIndex}, {currColIndex})");
                                return;
                            }
                            else if (matrix[currRowIndex, currColIndex] == 'c')
                            {
                                matrix[currRowIndex, currColIndex] = '*';

                                collectedCoal++;

                                if (collectedCoal == totalCoalToCollect)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRowIndex}, {currColIndex})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "down":
                        if (currRowIndex + 1 >= 0 && currRowIndex + 1 < size)
                        {
                            currRowIndex = currRowIndex + 1;

                            if (matrix[currRowIndex, currColIndex] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRowIndex}, {currColIndex})");
                                return;
                            }
                            else if (matrix[currRowIndex, currColIndex] == 'c')
                            {
                                matrix[currRowIndex, currColIndex] = '*';

                                collectedCoal++;

                                if (collectedCoal == totalCoalToCollect)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRowIndex}, {currColIndex})");
                                    return;
                                }
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"{totalCoalToCollect - collectedCoal} coals left. ({currRowIndex}, {currColIndex})");
        }
    }
}
