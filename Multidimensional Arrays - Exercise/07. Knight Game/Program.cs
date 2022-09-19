using System;

namespace _07._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int removedKnights = 0;

            for (int row = 0; row < size; row++)
            {
                char[] rowElements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            for (int i = 8; i > 0; i--)
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        char currElement = matrix[row, col];

                        if (currElement == 'K')
                        {
                            int danger = DangerLevel(matrix, row, col);
                            if (danger == i)
                            {
                                matrix[row, col] = '0';
                                removedKnights++;
                            }
                        }
                    }

                }
            }

            Console.WriteLine(removedKnights);
        }

        private static int DangerLevel(char[,] matrix, int row, int col)
        {
            int danger = 0;
            if (CheckForKnight(row + 2, col + 1, matrix)) danger++;
            if (CheckForKnight(row + 1, col + 2, matrix)) danger++;
            if (CheckForKnight(row + 2, col - 1, matrix)) danger++;
            if (CheckForKnight(row - 2, col - 1, matrix)) danger++;
            if (CheckForKnight(row - 2, col + 1, matrix)) danger++;
            if (CheckForKnight(row - 1, col + 2, matrix)) danger++;
            if (CheckForKnight(row + 1, col - 2, matrix)) danger++;
            if (CheckForKnight(row - 1, col - 2, matrix)) danger++;
            return danger;
        }

        private static bool CheckForKnight(int rowIndex, int colIndex, char[,] matrix)
        {
            if (rowIndex >= 0 && rowIndex < matrix.GetLength(0) &&
                colIndex >= 0 && colIndex < matrix.GetLength(1) &&
                matrix[rowIndex, colIndex] == 'K')
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
