using System;
using System.Linq;

namespace _08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 90/100

            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] rowElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            string[] inputAllCoordinates = Console.ReadLine().Split();

            foreach (var item in inputAllCoordinates)
            {
                string[] indexes = item.ToString().Split(",");

                int rowIndex = int.Parse(indexes[0]);
                int colIndex = int.Parse(indexes[1]);

                int bombValue = matrix[rowIndex, colIndex];

                if (matrix[rowIndex, colIndex] > 0)
                {
                    if (IsIndexValin(rowIndex, colIndex, matrix)) matrix[rowIndex, colIndex] = 0;
                    if (IsIndexValin(rowIndex, colIndex + 1, matrix) && matrix[rowIndex, colIndex + 1] > 0) matrix[rowIndex, colIndex + 1] -= bombValue;
                    if (IsIndexValin(rowIndex + 1, colIndex + 1, matrix) && matrix[rowIndex + 1, colIndex + 1] > 0) matrix[rowIndex + 1, colIndex + 1] -= bombValue;
                    if (IsIndexValin(rowIndex + 1, colIndex, matrix) && matrix[rowIndex + 1, colIndex] > 0) matrix[rowIndex + 1, colIndex] -= bombValue;
                    if (IsIndexValin(rowIndex + 1, colIndex - 1, matrix) && matrix[rowIndex + 1, colIndex - 1] > 0) matrix[rowIndex + 1, colIndex - 1] -= bombValue;
                    if (IsIndexValin(rowIndex, colIndex - 1, matrix) && matrix[rowIndex, colIndex - 1] > 0) matrix[rowIndex, colIndex - 1] -= bombValue;
                    if (IsIndexValin(rowIndex - 1, colIndex - 1, matrix) && matrix[rowIndex - 1, colIndex - 1] > 0) matrix[rowIndex - 1, colIndex - 1] -= bombValue;
                    if (IsIndexValin(rowIndex - 1, colIndex, matrix) && matrix[rowIndex - 1, colIndex] > 0) matrix[rowIndex - 1, colIndex] -= bombValue;
                    if (IsIndexValin(rowIndex - 1, colIndex + 1, matrix) && matrix[rowIndex - 1, colIndex + 1] > 0) matrix[rowIndex - 1, colIndex + 1] -= bombValue;
                }

            }

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsIndexValin(int rowIndex, int colIndex, int[,] matrix)
        {
            if (rowIndex >= 0 && rowIndex < matrix.GetLength(0) &&
                colIndex >= 0 && colIndex < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
