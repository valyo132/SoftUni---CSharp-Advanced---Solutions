using System;

namespace _02._The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        private static char[][] matrix;
        private static int armyRow;
        private static int armyCol;
        private static int armor;
        private static bool win = false;

        static void Main(string[] args)
        {
            armor = int.Parse(Console.ReadLine());
            if (armor <= 0)
            {
                return;
            }
            int size = int.Parse(Console.ReadLine());
            matrix = new char[size][];

            for (int row = 0; row < size; row++)
            {
                string elements = Console.ReadLine();
                matrix[row] = elements.ToCharArray();
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            string command = Console.ReadLine();
            while (true)
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                int enemyRow = int.Parse(tokens[1]);
                int enemyCol = int.Parse(tokens[2]);
                matrix[enemyRow][enemyCol] = 'O';

                switch (action)
                {
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                }

                if (armor <= 0 || win)
                    break;

                command = Console.ReadLine();
            }

            if (win)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }
            else
            {
                matrix[armyRow][armyCol] = 'X';
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }

            for (int row = 0; row < size; row++)
            {
                Console.WriteLine(String.Join("", matrix[row]));
            }
        }

        private static void Move(int row, int col)
        {
            armor--;

            if (IsValid(armyRow + row, armyCol + col))
            {
                matrix[armyRow][armyCol] = '-';
                armyRow += row;
                armyCol += col;

                if (matrix[armyRow][armyCol] == 'O')
                {
                    armor -= 2;
                    matrix[armyRow][armyCol] = 'A';
                }
                else if (matrix[armyRow][armyCol] == '-')
                {
                    matrix[armyRow][armyCol] = 'A';
                }
                else
                {
                    matrix[armyRow][armyCol] = '-';
                    win = true;
                }
            }
        }

        private static bool IsValid(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }
    }
}