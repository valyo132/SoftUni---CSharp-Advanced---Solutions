using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[size[0], size[1]];

            string inputSnake = Console.ReadLine();

            Queue<char> snake = new Queue<char>(inputSnake.ToCharArray());


            for (int row = 0; row < size[0]; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < size[1]; col++)
                    {
                        matrix[row, col] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
