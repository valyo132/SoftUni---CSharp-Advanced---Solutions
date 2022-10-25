using System;

namespace _02._Bee
{
    internal class Program
    {
        private static char[,] matrix;
        private static int beeRow;
        private static int beeCol;
        private static int pollinatesFlowers;
        private static bool beeLost = false;

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
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
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

                if (beeLost)
                    break;
            }

            if (beeLost)
                Console.WriteLine("The bee got lost!");

            if (pollinatesFlowers >= 5)
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatesFlowers} flowers!");
            else
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatesFlowers} flowers more");

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
            if (IsValid(beeRow + row, beeCol + col))
            {
                matrix[beeRow, beeCol] = '.';
                beeRow += row;
                beeCol += col;

                if (matrix[beeRow, beeCol] == 'f')
                {
                    matrix[beeRow, beeCol] = 'B';
                    pollinatesFlowers++;
                }
                else if (matrix[beeRow, beeCol] == '.')
                {
                    matrix[beeRow, beeCol] = 'B';
                }
                else
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow += row;
                    beeCol += col;

                    if (matrix[beeRow, beeCol] == 'f')
                        pollinatesFlowers++;

                    matrix[beeRow, beeCol] = 'B';
                }
            }
            else
            {
                matrix[beeRow, beeCol] = '.';
                beeLost = true;
            }
        }

        private static bool IsValid(int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }
}
