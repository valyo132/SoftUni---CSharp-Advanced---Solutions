using System;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[size[0], size[1]];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < size[0]; row++)
            {
                char[] rowElements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = rowElements[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string moves = Console.ReadLine();

            foreach (char move in moves)
            {
                bool won = false;
                bool loss = false;

                int newplayerRow = playerRow;
                int newplayerCol = playerCol;

                switch (move)
                {
                    case 'U':
                        matrix[newplayerRow, newplayerCol] = '.';
                        newplayerRow--;
                        MovePlayer(newplayerRow, playerCol, matrix, ref won, ref loss);

                        break;
                    case 'D':
                        matrix[newplayerRow, newplayerCol] = '.';
                        newplayerRow++;
                        MovePlayer(newplayerRow, playerCol, matrix, ref won, ref loss);

                        break;
                    case 'L':
                        matrix[newplayerRow, newplayerCol] = '.';
                        newplayerCol--;
                        MovePlayer(playerRow, newplayerCol, matrix, ref won, ref loss);

                        break;
                    case 'R':
                        matrix[newplayerRow, newplayerCol] = '.';
                        newplayerCol++;
                        MovePlayer(playerRow, newplayerCol, matrix, ref won, ref loss);

                        break;
                }

                matrix = SpreadBunnies(matrix, ref loss);

                if (won)
                {
                    PrintMatrix(matrix);

                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }

                playerRow = newplayerRow;
                playerCol = newplayerCol;

                if (loss)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
            }
        }

        public static char[,] SpreadBunnies(char[,] matrix, ref bool loss)
        {
            char[,] newMatrix = CopyMatrix(matrix);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (IsCellValid(row - 1, col, matrix))
                        {
                            if (matrix[row - 1, col] == 'P')
                            {
                                loss = true;
                            }

                            newMatrix[row - 1, col] = 'B';
                        }
                        if (IsCellValid(row + 1, col, matrix))
                        {
                            if (matrix[row + 1, col] == 'P')
                            {
                                loss = true;
                            }

                            newMatrix[row + 1, col] = 'B';
                        }
                        if (IsCellValid(row, col - 1, matrix))
                        {
                            if (matrix[row, col - 1] == 'P')
                            {
                                loss = true;
                            }

                            newMatrix[row, col - 1] = 'B';
                        }
                        if (IsCellValid(row, col + 1, matrix))
                        {
                            if (matrix[row, col + 1] == 'P')
                            {
                                loss = true;
                            }

                            newMatrix[row, col + 1] = 'B';
                        }
                    }
                }
            }

            return newMatrix;
        }

        private static char[,] CopyMatrix(char[,] matrix)
        {
            char[,] copy = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    copy[row, col] = matrix[row, col];
                }
            }

            return copy;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static void MovePlayer(int playerRow, int playerCol, char[,] matrix, ref bool won, ref bool loss)
        {
            if (IsCellValid(playerRow, playerCol, matrix))
            {
                if (matrix[playerRow, playerCol] == 'B')
                {
                    loss = true;
                }
                else
                {
                    matrix[playerRow, playerCol] = 'P';
                }
            }
            else
            {
                won = true;
            }
        }

        static bool IsCellValid(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
