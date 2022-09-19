using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] rowNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedArray[row] = rowNumbers;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "End")
                {
                    break;
                }

                switch (command[0])
                {
                    case "Add":
                        int row = int.Parse(command[1]);
                        int col = int.Parse(command[2]);
                        double value = int.Parse(command[3]);

                        if (row >= 0 && row < rows &&
                            col >= 0 && col < jaggedArray[row].Length)
                        {
                            jaggedArray[row][col] += value;
                        }
                        break;
                    case "Subtract":
                        int row1 = int.Parse(command[1]);
                        int col1 = int.Parse(command[2]);
                        double value1 = int.Parse(command[3]);

                        if (row1 >= 0 && row1 < rows &&
                            col1 >= 0 && col1 < jaggedArray[row1].Length)
                        {
                            jaggedArray[row1][col1] -= value1;
                        }
                        break;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
