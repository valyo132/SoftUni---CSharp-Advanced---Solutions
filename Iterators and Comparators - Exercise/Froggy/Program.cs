using System;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(numbers);

            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
