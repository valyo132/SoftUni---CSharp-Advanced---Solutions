using System;

namespace _02._Snake
{
    internal class Program
    {
        private static char[,] matrix;
        private static int snakeRow;
        private static int snakeCol;
        private static int foodEaten;
        private static bool leave;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            matrix = new char[size, size];

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
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

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

                if (foodEaten >= 10 || leave == true)
                    break;
            }

            if (leave)
                Console.WriteLine("Game over!");
            else
                Console.WriteLine("You won! You fed the snake.");

            Console.WriteLine($"Food eaten: {foodEaten}");

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
            if (IsValid(snakeRow + row, snakeCol + col))
            {
                matrix[snakeRow, snakeCol] = '.';
                snakeRow += row;
                snakeCol += col;

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    matrix[snakeRow, snakeCol] = 'S';
                    foodEaten++;
                }
                else if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] == 'B')
                            {
                                snakeRow = i;
                                snakeCol = j;
                            }
                        }
                    }

                    matrix[snakeRow, snakeCol] = 'S';
                }
                else
                {
                    matrix[snakeRow, snakeCol] = 'S';
                }
            }
            else
            {
                matrix[snakeRow, snakeCol] = '.';
                leave = true;
            }
        }

        private static bool IsValid(int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }
}
