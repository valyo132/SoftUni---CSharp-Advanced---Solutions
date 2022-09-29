using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string> printKnight = knight => Console.WriteLine($"Sir {knight}");

            foreach (var name in names)
            {
                printKnight(name);
            }
        }
    }
}
