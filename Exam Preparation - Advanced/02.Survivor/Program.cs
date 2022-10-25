using System;
using System.Linq;

namespace _02.Survivor
{
    internal class Program
    {
        private static char[][] matrix;
        private static int totalTokens;
        private static int opponentTokens;
        private static int currRow;
        private static int currCol;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = string.Join("", Console.ReadLine().Split()).ToCharArray();
            }

            string command;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                if (action == "Find")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    Find(row, col);
                }
                else if (action == "Opponent")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    string direction = tokens[3];
                    currRow = row;
                    currCol = col;
                    if (IsValid(currRow, currCol))
                    {
                        if (matrix[currRow][currCol] == 'T')
                        {
                            opponentTokens++;
                            matrix[currRow][currCol] = '-';
                        }
                    }
                    else
                        continue;

                    switch (direction)
                    {
                        case "right":
                            for (int i = 0; i < 3; i++)
                                Move(0, 1, direction);
                            break;
                        case "left":
                            for (int i = 0; i < 3; i++)
                                Move(0, -1, direction);
                            break;
                        case "up":
                            for (int i = 0; i < 3; i++)
                                Move(-1, 0, direction);
                            break;
                        case "down":
                            for (int i = 0; i < 3; i++)
                                Move(1, 0, direction);
                            break;
                    }
                }
            }

            Print(rows);
        }

        private static void Move(int row, int col, string direction)
        {
            if (IsValid(currRow + row, currCol + col))
            {
                currRow += row;
                currCol += col;
                if (matrix[currRow][currCol] == 'T')
                {
                    opponentTokens++;
                    matrix[currRow][currCol] = '-';
                }
            }
        }

        private static void Find(int row, int col)
        {
            if (IsValid(row, col))
            {
                if (matrix[row][col] == 'T')
                {
                    totalTokens++;
                    matrix[row][col] = '-';
                }
            }
        }

        private static bool IsValid(int row, int col)
            => row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;

        private static void Print(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Collected tokens: {totalTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
    }
}
