using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> revearedWords = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                revearedWords.Push(input[i]);
            }

            Console.WriteLine(string.Join("", revearedWords));
        }
    }
}
