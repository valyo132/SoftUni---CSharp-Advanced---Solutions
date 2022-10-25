using System;

namespace _02._Re_Volt
{
    internal class Program
    {
        private static char[,] matrix;
        private static int currRow;
        private static int currCol;
        private static bool win = false;
        private static string direction;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            matrix = new char[size, size];

            int countOfCommands = int.Parse(Console.ReadLine());

            for (int row = 0; row < size; row++)
            {
                string elements = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();
                direction = command;

                switch (command)
                {
                    case "right":
                        Move(0, 1);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                }

                if (win)
                {
                    break;
                }
            }

            if (win)
                Console.WriteLine("Player won!");
            else
                Console.WriteLine("Player lost!");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void Move(int row, int col)
        {
            if (IsValid(currRow + row, currCol + col))
            {
                if (matrix[currRow, currCol] != 'B' && matrix[currRow, currCol] != 'T' && matrix[currRow, currCol] != 'F')
                {
                    matrix[currRow, currCol] = '-';
                }
                currRow += row;
                currCol += col;

                if (matrix[currRow, currCol] == 'B')
                {
                    Move(row, col);
                }
                else if (matrix[currRow, currCol] == 'T')
                {
                    currRow -= row;
                    currCol -= col;
                    matrix[currRow, currCol] = 'f';
                }
                else if (matrix[currRow, currCol] == '-')
                {
                    matrix[currRow, currCol] = 'f';
                }
                else
                {
                    matrix[currRow, currCol] = 'f';
                    win = true;
                }
            }
            else
            {
                if (matrix[currRow, currCol] != 'B' && matrix[currRow, currCol] != 'T')
                {
                    matrix[currRow, currCol] = '-';
                }

                if (direction == "up")
                    currRow = matrix.GetLength(0) - 1;
                else if (direction == "down")
                    currRow = 0;
                else if (direction == "left")
                    currCol = matrix.GetLength(1) - 1;
                else if (direction == "right")
                    currCol = 0;

                Move(0, 0);
            }
        }

        private static bool IsValid(int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }
}
