using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> check =
                (string x) => x.Length > 0 && char.IsUpper(x[0]);

            Console.WriteLine(String.Join("\n",Console.ReadLine().Split()
                .Where(x => check(x))));
        }
    }
}
