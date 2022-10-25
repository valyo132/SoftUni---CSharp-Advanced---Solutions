using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Garden
{
    internal class Program
    {
        private static int[,] matrix;
        //private static List<string> locations;

        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            matrix = new int[sizes[0], sizes[1]];

            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] indexes = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int row = indexes[0];
                int col = indexes[1];
                Plant(row, col);
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void Plant(int row, int col)
        {
            if (IsValid(row, col))
            {
                matrix[row, col]++;

                //right
                for (int i = col + 1; i < matrix.GetLength(1); i++)
                    matrix[row, i]++;
                //left
                for (int i = col - 1; i >= 0; i--)
                    matrix[row, i]++;
                //down
                for (int i = row + 1; i < matrix.GetLength(0); i++)
                    matrix[i, col]++;
                //up
                for (int i = row - 1; i >= 0; i--)
                    matrix[i, col]++;

            }
            else
            {
                Console.WriteLine("Invalid coordinates.");
            }
        }

        private static bool IsValid(int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }
}
