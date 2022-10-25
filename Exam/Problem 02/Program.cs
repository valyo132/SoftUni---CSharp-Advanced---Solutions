using System;

namespace Problem_02
{
    internal class Program
    {
        private static char[,] matrix;
        private static int carRow;
        private static int carCol;
        private static int kilometers;
        private static bool finish;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            matrix = new char[size, size];

            string racingNumber = Console.ReadLine();

            for (int row = 0; row < size; row++)
            {
                char[] elements = string.Join("", Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            carRow = 0;
            carCol = 0;
            matrix[carRow, carCol] = 'C';
            // ako na [0,0] ima element?

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

                if (finish)
                    break;
            }

            if (finish)
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {kilometers} km.");

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
            // IsValid ?!
            matrix[carRow, carCol] = '.';
            carRow += row;
            carCol += col;

            if (matrix[carRow, carCol] == '.')
            {
                matrix[carRow, carCol] = 'C';
                kilometers += 10;
            }
            else if (matrix[carRow, carCol] == 'T')
            {
                matrix[carRow, carCol] = '.';
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 'T')
                        {
                            carRow = i;
                            carCol = j;
                        }
                    }
                }
                matrix[carRow, carCol] = 'C';
                kilometers += 30;
            }
            else
            {
                matrix[carRow, carCol] = 'C';
                kilometers += 10;
                finish = true;
            }
        }
    }
}
