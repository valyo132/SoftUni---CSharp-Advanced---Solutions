using System;

namespace _02._Selling
{
    internal class Program
    {
        private static char[,] matrix;
        private static int sellerRow;
        private static int sellerCol;
        private static int value;
        private static bool leave = false;

        static void Main(string[] args)
        {
            // client (digit) = sum the digit, client dissapiear
            // pillar ('O') = currPiller = 'S', find the other piller and make it 'S'
            // outOfMatrix = end commands
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
                    if (matrix[row, col] == 'S')
                    {
                        sellerRow = row;
                        sellerCol = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

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

                if (value >= 50 || leave == true)
                {
                    break;
                }
            }

            if (leave)
                Console.WriteLine("Bad news, you are out of the bakery.");
            else
                Console.WriteLine("Good news! You succeeded in collecting enough money!");

            Console.WriteLine($"Money: {value}");

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
            if (isValid(sellerRow + row, sellerCol + col))
            {
                matrix[sellerRow, sellerCol] = '-';
                sellerRow += row;
                sellerCol += col;

                if (matrix[sellerRow, sellerCol] == 'O')
                {
                    matrix[sellerRow, sellerCol] = '-';

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] == 'O')
                            {
                                sellerRow = i;
                                sellerCol = j;
                            }
                        }
                    }
                }
                else if (matrix[sellerRow, sellerCol] == '-')
                {
                    matrix[sellerRow, sellerCol] = 'S';
                }
                else
                {
                    int number = int.Parse(matrix[sellerRow, sellerCol].ToString());
                    value += number;
                    matrix[sellerRow, sellerCol] = 'S';
                }
            }
            else
            {
                matrix[sellerRow, sellerCol] = '-';
                leave = true;
            }
        }

        private static bool isValid(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
