using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> isNameValid =
                (name, n) => name.ToCharArray().Select(x => (int)x).Sum() >= n;

            Func<List<string>, Func<string, int, bool>, string> nameToPrint =
                (names, isNameValid) => names.Find(x => isNameValid(x, n));

            string result = nameToPrint(names, isNameValid);
            Console.WriteLine(result);
        }
    }
}
