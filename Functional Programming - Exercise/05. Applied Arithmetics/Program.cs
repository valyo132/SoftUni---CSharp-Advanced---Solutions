using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(x => x + 1).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => x * 2).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => x - 1).ToList();
                        break;
                    case "print":
                        Console.WriteLine(String.Join(" ", numbers));
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
