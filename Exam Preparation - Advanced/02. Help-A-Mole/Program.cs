using System;

namespace _02._Help_A_Mole
{
    internal class Program
    {
        private static char[,] matrix;
        private static int currRow;
        private static int currCol;
        private static int totalPoints;
        private static bool win = false;

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
                    if (matrix[row, col] == 'M')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
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

                if (totalPoints >= 25)
                {
                    break;
                }
            }

            PrintResult(size);
        }

        private static void PrintResult(int size)
        {
            if (totalPoints >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {totalPoints} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {totalPoints} points.");
            }

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
                if (matrix[currRow + row, currCol + col] == '-')
                {
                    matrix[currRow, currCol] = '-';
                    currRow += row;
                    currCol += col;

                    matrix[currRow, currCol] = 'M';
                }
                else if (matrix[currRow + row, currCol + col] == 'S')
                {
                    matrix[currRow, currCol] = '-';
                    currRow += row;
                    currCol += col;

                    matrix[currRow, currCol] = 'M';

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] == 'S')
                            {
                                matrix[currRow, currCol] = '-';

                                currRow = i;
                                currCol = j;
                            }
                        }
                    }

                    totalPoints -= 3;
                    matrix[currRow, currCol] = 'M';
                }
                else
                {
                    matrix[currRow, currCol] = '-';
                    currRow += row;
                    currCol += col;

                    totalPoints += int.Parse(matrix[currRow, currCol].ToString());

                    matrix[currRow, currCol] = 'M';
                }
            }
            else
            {
                Console.WriteLine("Don't try to escape the playing field!");
            }
        }

        public static bool IsValid(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
