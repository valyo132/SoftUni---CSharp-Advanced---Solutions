using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> isNameValid = (string name) => name.Length <= n;

            Console.WriteLine(String.Join("\n", names.Where(x => isNameValid(x))));
        }
    }
}
