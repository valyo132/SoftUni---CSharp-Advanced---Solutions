using System;

namespace _07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsInput = int.Parse(Console.ReadLine());
            long[][] triangle = new long[rowsInput][];

            for (int row = 0; row < rowsInput; row++)
            {
                triangle[row] = new long[row + 1];
            }

            triangle[0][0] = 1;

            for (int row = 0; row < rowsInput - 1; row++)
            {
                for (int col = 0; col < triangle[row].Length; col++)
                {
                    triangle[row + 1][col] += triangle[row][col];
                    triangle[row + 1][col + 1] += triangle[row][col];
                }
            }

            for (int row = 0; row < rowsInput; row++)
            {
                for (int col = 0; col < row; col++)
                {
                    Console.Write(triangle[row][col] + " ");
                }

                Console.Write("1");

                Console.WriteLine();
            }
        }
    }
}
