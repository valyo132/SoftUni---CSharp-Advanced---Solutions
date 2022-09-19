using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string[,] matrix = new string[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "END")
                {
                    break;
                }

                if (command[0] == "swap" && command.Length == 5)
                {
                    int row1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int row2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);

                    if (row1 >= 0 && row1 < size[0]
                        && col1 >= 0 && col1 < size[1]
                        && row2 >= 0 && row2 < size[0]
                        && col2 >= 0 && col2 < size[1])
                    {
                        var firstNumber = matrix[row1, col1];
                        var secondNumber = matrix[row2, col2];

                        matrix[row1, col1] = secondNumber;
                        matrix[row2, col2] = firstNumber;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
