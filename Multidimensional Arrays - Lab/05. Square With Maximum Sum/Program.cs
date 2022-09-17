using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matirx = new int[size[0], size[1]];

            for (int row = 0; row < matirx.GetLength(0); row++)
            {
                int[] rowNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matirx.GetLength(1); col++)
                {
                    matirx[row, col] = rowNumbers[col];
                }
            }

            int max = 0;

            int[] firstRow = new int[2];
            int[] secondRow = new int[2];

            for (int row = 0; row < matirx.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matirx.GetLength(1) - 1; col++)
                {
                    int sum = 0;

                    sum += matirx[row, col];
                    sum += matirx[row, col + 1];
                    sum += matirx[row + 1, col];
                    sum += matirx[row + 1, col + 1];

                    if (sum > max)
                    {
                        max = sum;

                        firstRow = new int[] { matirx[row, col], matirx[row, col + 1] };
                        secondRow = new int[] { matirx[row + 1, col], matirx[row + 1, col + 1] };
                    }
                }
            }

            Console.WriteLine(String.Join(" ", firstRow));
            Console.WriteLine(String.Join(" ", secondRow));

            Console.WriteLine(max);
        }
    }
}
