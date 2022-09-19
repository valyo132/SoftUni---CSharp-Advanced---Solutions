using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 80/100

            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            double[,] matrix = new double[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            double maxSum = 0;

            int startRowIndex = 0;
            int startColIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    double sum = 0;

                    sum += matrix[row, col];
                    sum += matrix[row, col + 1];
                    sum += matrix[row, col + 2];
                    sum += matrix[row + 1, col];
                    sum += matrix[row + 1, col + 1];
                    sum += matrix[row + 1, col + 2];
                    sum += matrix[row + 2, col];
                    sum += matrix[row + 2, col + 1];
                    sum += matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;

                        startRowIndex = row;
                        startColIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = startRowIndex; row < startRowIndex + 3; row++)
            {
                for (int col = startColIndex; col < startColIndex + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
