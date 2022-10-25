using System;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        private static char[,] matrix;
        private static int black;
        private static int summer;
        private static int white;
        private static int boarRow;
        private static int boarCol;
        private static int eatenTruffles;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] elements = string.Join("", Console.ReadLine().Split()).ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Collect":
                        Collect(tokens);
                        break;
                    case "Wild_Boar":
                        WildBoar(tokens);
                        break;
                }
            }

            Console.WriteLine($"Peter manages to harvest {black} black, {summer} summer, and {white} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenTruffles} truffles.");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void WildBoar(string[] tokens)
        {
            boarRow = int.Parse(tokens[1]);
            boarCol = int.Parse(tokens[2]);
            string direction = tokens[3];

            switch (direction)
            {
                case "left":
                    Move(0, -2);
                    break;
                case "right":
                    Move(0, 2);
                    break;
                case "up":
                    Move(-2, 0);
                    break;
                case "down":
                    Move(2, 0);
                    break;
            }
        }

        private static void Move(int row, int col)
        {
            while (IsValid(boarRow, boarCol))
            {
                if (matrix[boarRow, boarCol] != '-')
                {
                    eatenTruffles++;
                }
                matrix[boarRow, boarCol] = '-';

                boarRow += row;
                boarCol += col;
            }
        }

        private static void Collect(string[] tokens)
        {
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);

            if (IsValid(row, col))
            {
                if (matrix[row, col] == 'B')
                    black++;
                else if (matrix[row, col] == 'S')
                    summer++;
                else if (matrix[row, col] == 'W')
                    white++;

                matrix[row, col] = '-';
            }
        }

        private static bool IsValid(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
