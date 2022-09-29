using System;
using System.Linq;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string> printUser = user => Console.WriteLine(user);

            foreach (var user in names)
            {
                printUser(user);
            }
        }
    }
}
