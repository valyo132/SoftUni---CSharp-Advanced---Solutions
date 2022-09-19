using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] rowNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowNumbers[col];
                }
            }

            int primaryDiagonalSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primaryDiagonalSum += matrix[i, i];
            }

            int secondaryDiagonalSum = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = size - row - 1; col >= 0; col--)
                {
                    secondaryDiagonalSum += matrix[row, col];
                    break;
                }
            }

            int difference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(difference);
        }
    }
}
