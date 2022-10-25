using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Warships
{
    internal class Program
    {
        private static char[,] matrix;
        private static int playerOneShips;
        private static int playerTwoShips;
        private static int size;
        private static bool playerOneWin;
        private static bool playerTwoWin;

        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());
            string[] coordinatesInpt = Console.ReadLine().Split(",").ToArray();
            matrix = new char[size, size];

            List<string> coordinates = new List<string>(coordinatesInpt);

            for (int row = 0; row < size; row++)
            {
                char[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == '<')
                    {
                        playerOneShips++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }

            int totalShips = playerOneShips + playerTwoShips;

            foreach (var item in coordinates)
            {
                string[] tokens = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(tokens[0]);
                int col = int.Parse(tokens[1]);

                Attack(row, col);

                if (playerOneShips <= 0)
                {
                    playerTwoWin = true;
                    break;
                }
                else if (playerTwoShips <= 0)
                {
                    playerOneWin = true;
                    break;
                }
            }

            int sunkShips = totalShips - (playerOneShips + playerTwoShips);

            if (playerOneWin)
            {
                Console.WriteLine($"Player One has won the game! {sunkShips} ships have been sunk in the battle.");
            }
            else if (playerTwoWin)
            {
                Console.WriteLine($"Player Two has won the game! {sunkShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
        }

        private static void Attack(int row, int col)
        {
            if (IsValid(row, col))
            {
                if (matrix[row, col] == '#')
                {
                    Explode(row, col);
                }
                else if (matrix[row, col] == '<')
                {
                    playerOneShips--;
                    matrix[row, col] = 'X';
                }
                else if (matrix[row, col] == '>')
                {
                    playerTwoShips--;
                    matrix[row, col] = 'X';
                }
            }
        }

        private static void Explode(int row, int col)
        {
            if (IsValid(row - 1, col + 1))
            {
                if (matrix[row - 1, col + 1] == '<') playerOneShips--;
                else if (matrix[row - 1, col + 1] == '>') playerTwoShips--;
                matrix[row - 1, col + 1] = 'X';
            }

            if (IsValid(row, col + 1))
            {
                if (matrix[row, col + 1] == '<') playerOneShips--;
                else if (matrix[row, col + 1] == '>') playerTwoShips--;
                matrix[row, col + 1] = 'X';
            }

            if (IsValid(row + 1, col + 1))
            {
                if (matrix[row + 1, col + 1] == '<') playerOneShips--;
                else if (matrix[row + 1, col + 1] == '>') playerTwoShips--;
                matrix[row + 1, col + 1] = 'X';
            }

            if (IsValid(row + 1, col))
            {
                if (matrix[row + 1, col] == '<') playerOneShips--;
                else if (matrix[row + 1, col] == '>') playerTwoShips--;
                matrix[row + 1, col] = 'X';
            }

            if (IsValid(row + 1, col - 1))
            {
                if (matrix[row + 1, col - 1] == '<') playerOneShips--;
                else if (matrix[row + 1, col - 1] == '>') playerTwoShips--;
                matrix[row + 1, col - 1] = 'X';
            }

            if (IsValid(row, col - 1))
            {
                if (matrix[row, col - 1] == '<') playerOneShips--;
                else if (matrix[row, col - 1] == '>') playerTwoShips--;
                matrix[row, col - 1] = 'X';
            }

            if (IsValid(row - 1, col - 1))
            {
                if (matrix[row - 1, col - 1] == '<') playerOneShips--;
                else if (matrix[row - 1, col - 1] == '>') playerTwoShips--;
                matrix[row - 1, col - 1] = 'X';
            }

            if (IsValid(row - 1, col))
            {
                if (matrix[row - 1, col] == '<') playerOneShips--;
                else if (matrix[row - 1, col] == '>') playerTwoShips--;
                matrix[row - 1, col] = 'X';
            }
        }

        private static bool IsValid(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
