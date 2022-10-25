using System;
using System.Collections.Generic;

namespace _02._Pawn_Wars
{
    internal class Program
    {
        private static char[,] matrix;
        private static int whiteRow;
        private static int whiteCol;
        private static int blackRow;
        private static int blackCol;
        private static bool whiteWin = false;
        private static bool blackWin = false;

        private static Dictionary<int, int> rows = new Dictionary<int, int>()
        {
            [0] = 8,
            [1] = 7,
            [2] = 6,
            [3] = 5,
            [4] = 4,
            [5] = 3,
            [6] = 2,
            [7] = 1,
        };

        private static Dictionary<int, char> columns = new Dictionary<int, char>()
        {
            [0] = 'a',
            [1] = 'b',
            [2] = 'c',
            [3] = 'd',
            [4] = 'e',
            [5] = 'f',
            [6] = 'g',
            [7] = 'h',
        };

        static void Main(string[] args)
        {
            matrix = new char[8, 8];

            for (int row = 0; row < 8; row++)
            {
                string elements = Console.ReadLine();

                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (matrix[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }

                    if (matrix[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            while (true)
            {
                WhiteMove();
                if (whiteWin)
                {
                    Console.WriteLine($"Game over! White capture on {columns[whiteCol]}{rows[whiteRow]}.");
                    break;
                }
                BlackMove();
                if (blackWin)
                {
                    Console.WriteLine($"Game over! Black capture on {columns[blackCol]}{rows[blackRow]}.");
                    break;
                }
            }
        }

        private static void BlackMove()
        {
            if (whiteRow == blackRow + 1 && (whiteCol == blackCol + 1 || whiteCol == blackCol - 1))
            {
                blackRow = whiteRow;
                blackCol = whiteCol;
                blackWin = true;
            }
            else if (++blackRow == 7)
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {columns[blackCol]}{rows[blackRow]}.");
                Environment.Exit(0);
            }
        }

        private static void WhiteMove()
        {
            if (blackRow == whiteRow - 1 && (blackCol == whiteCol - 1 || blackCol == whiteCol + 1))
            {
                whiteRow = blackRow;
                whiteCol = blackCol;
                whiteWin = true;
            }
            else if (--whiteRow == 0)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {columns[whiteCol]}{rows[whiteRow]}.");
                Environment.Exit(0);
            }
        }
    }
}
