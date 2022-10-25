using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Beaver_at_Work
{
    internal class Program
    {
        private static char[,] matrix;
        private static int countOfBranches = 0;
        private static int copy;

        public class Beaver
        {
            public Beaver()
            {
                WoodBranches = new List<char>();
            }

            public int BeaverRow { get; set; }
            public int BeaverCol { get; set; }
            public string Direction { get; set; }
            public List<char> WoodBranches { get; set; }
        }

        static void Main(string[] args)
        {
            Beaver beaver = new Beaver();
            int size = int.Parse(Console.ReadLine());
            matrix = new char[size, size];

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
                    if (matrix[row, col] == 'B')
                    {
                        beaver.BeaverRow = row;
                        beaver.BeaverCol = col;
                    }
                    else if (char.IsLower(matrix[row, col]))
                    {
                        countOfBranches++;
                    }
                }
            }
            copy = countOfBranches;

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "left":
                        beaver.Direction = "left";
                        Move(0, -1, beaver);
                        break;
                    case "right":
                        beaver.Direction = "right";
                        Move(0, +1, beaver);
                        break;
                    case "up":
                        beaver.Direction = "up";
                        Move(-1, 0, beaver);
                        break;
                    case "down":
                        beaver.Direction = "down";
                        Move(+1, 0, beaver);
                        break;
                }

                if (countOfBranches == 0)
                    break;
            }

            if (countOfBranches == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {copy} wood branches: {string.Join(", ", beaver.WoodBranches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countOfBranches} branches left.");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        private static void Move(int row, int col, Beaver beaver)
        {
            if (IsValid(beaver.BeaverRow + row, beaver.BeaverCol + col))
            {
                var ch = matrix[beaver.BeaverRow + row, beaver.BeaverCol + col];

                matrix[beaver.BeaverRow, beaver.BeaverCol] = '-';
                beaver.BeaverRow += row;
                beaver.BeaverCol += col;

                if (Char.IsLower(ch))
                {
                    matrix[beaver.BeaverRow, beaver.BeaverCol] = 'B';
                    beaver.WoodBranches.Add(ch);
                    countOfBranches--;
                }
                else if (ch == 'F')
                {
                    matrix[beaver.BeaverRow, beaver.BeaverCol] = '-';
                    Swim(beaver);
                }
                else
                {
                    matrix[beaver.BeaverRow, beaver.BeaverCol] = 'B';
                }
            }
            else
            {
                if (beaver.WoodBranches.Count > 0)
                {
                    beaver.WoodBranches.RemoveAt(beaver.WoodBranches.Count - 1);
                    copy--;
                }
            }
        }

        private static void Swim(Beaver beaver)
        {
            int max = matrix.GetLength(0) - 1;
            if (beaver.Direction == "up" && beaver.BeaverRow == 0) beaver.Direction = "down";
            else if (beaver.Direction == "down" && beaver.BeaverRow == max) beaver.Direction = "up";
            if (beaver.Direction == "left" && beaver.BeaverCol == 0) beaver.Direction = "right";
            if (beaver.Direction == "right" && beaver.BeaverCol == max) beaver.Direction = "left";

            switch (beaver.Direction)
            {
                case "left":
                    beaver.BeaverCol = 0;
                    break;
                case "right":
                    beaver.BeaverCol = max;
                    break;
                case "up":
                    beaver.BeaverRow = 0;
                    break;
                case "down":
                    beaver.BeaverRow = max;
                    break;
            }
            Move(0, 0, beaver);
        }

        private static bool IsValid(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
