using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                if (input == "Paid")
                {
                    Console.WriteLine(String.Join("\n", names));
                    names.Clear();
                    continue;
                }

                names.Enqueue(input);
            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
