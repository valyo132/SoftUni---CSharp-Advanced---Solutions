using System;

namespace _02.Super_Mario
{
    internal class Program
    {
        private static char[][] matrix;
        private static int marioRow;
        private static int marioCol;
        private static bool win;
        private static int lives;

        static void Main(string[] args)
        {
            lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                string elements = Console.ReadLine();
                matrix[i] = elements.ToCharArray();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                matrix[row][col] = 'B';

                switch (action)
                {
                    case "D":
                        Move(0, 1);
                        break;
                    case "A":
                        Move(0, -1);
                        break;
                    case "W":
                        Move(-1, 0);
                        break;
                    case "S":
                        Move(1, 0);
                        break;
                }

                if (lives <= 0 || win)
                    break;
            }

            if (win)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                matrix[marioRow][marioCol] = 'X';
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(String.Join("", matrix[row]));
            }
        }

        private static void Move(int row, int col)
        {
            lives--;

            if (IsValid(marioRow + row, marioCol + col))
            {
                matrix[marioRow][marioCol] = '-';
                marioRow += row;
                marioCol += col;

                if (matrix[marioRow][marioCol] == 'B')
                {
                    lives -= 2;
                    matrix[marioRow][marioCol] = 'M';
                }
                else if (matrix[marioRow][marioCol] == '-')
                {
                    matrix[marioRow][marioCol] = 'M';
                }
                else
                {
                    matrix[marioRow][marioCol] = '-';
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
