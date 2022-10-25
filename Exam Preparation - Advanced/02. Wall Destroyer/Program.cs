using System;
using System.Linq;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        private static int vankoRow;
        private static int vankoCol;

        private static char[,] matrix;

        private static int rods;
        private static int holes = 1;
        private static bool dead = false;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            matrix = new char[size, size];

            CreateTheMatrix(size, matrix);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "down":
                        Move(1, 0);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                    case "up":
                        Move(-1, 0);
                        break;
                }

                if (dead)
                {
                    Print(size);
                    return;
                }
            }

            Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
            Print(size);
        }

        private static void Print(int size)
        {
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
            if (IsValid(vankoRow + row, vankoCol + col))
            {
                if (matrix[vankoRow + row, vankoCol + col] == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    rods++;
                }
                else if (matrix[vankoRow + row, vankoCol + col] == 'C')
                {
                    matrix[vankoRow, vankoCol] = '*';
                    vankoRow = vankoRow + row;
                    vankoCol = vankoCol + col;
                    holes++;

                    matrix[vankoRow, vankoCol] = 'E';

                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");

                    dead = true;
                }
                else if (matrix[vankoRow + row, vankoCol + col] == '-')
                {
                    matrix[vankoRow, vankoCol] = '*';
                    vankoRow = vankoRow + row;
                    vankoCol = vankoCol + col;
                    holes++;

                    matrix[vankoRow, vankoCol] = 'V';

                }
                else if (matrix[vankoRow + row, vankoCol + col] == '*')
                {
                    matrix[vankoRow, vankoCol] = '*';
                    vankoRow = vankoRow + row;
                    vankoCol = vankoCol + col;

                    matrix[vankoRow, vankoCol] = 'V';

                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                }
            }
        }

        public static bool IsValid(int vankoRow, int vankoCol)
        {
            return vankoRow >= 0 && vankoRow < matrix.GetLength(0) && vankoCol >= 0 && vankoCol < matrix.GetLength(1);
        }

        private static void CreateTheMatrix(int size, char[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                string rowElements = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }
        }
    }
}
