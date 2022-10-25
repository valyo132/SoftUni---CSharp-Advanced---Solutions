using System;

namespace _02._Armory
{
    internal class Program
    {
        private static char[,] matrix;
        private static int currRow;
        private static int currCol;
        private static int value;
        private static bool leftTheArmory = false;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string elements = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'A')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != null)
            {
                switch (command)
                {
                    case "right":
                        Move(0, 1);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                    case "up":
                        Move(-1, 0);
                        break;
                }

                if (value >= 65 || leftTheArmory)
                    break;
            }

            if (leftTheArmory)
                Console.WriteLine("I do not need more swords!");
            else
                Console.WriteLine("Very nice swords, I will come back for more!");

            Console.WriteLine($"The king paid {value} gold coins.");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
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
                matrix[currRow, currCol] = '-';
                currRow += row;
                currCol += col;

                if (matrix[currRow, currCol] == '-')
                {
                    matrix[currRow, currCol] = 'A';
                }
                else if (matrix[currRow, currCol] == 'M')
                {
                    matrix[currRow, currCol] = '-';

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            if (matrix[i, k] == 'M')
                            {
                                currRow = i;
                                currCol = k;
                            }
                        }
                    }

                    matrix[currRow, currCol] = 'A';
                }
                else
                {
                    int number = int.Parse(matrix[currRow, currCol].ToString());
                    value += number;
                    matrix[currRow, currCol] = 'A';
                }
            }
            else
            {
                matrix[currRow, currCol] = '-';
                leftTheArmory = true;
            }
        }

        private static bool IsValid(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
