﻿using System;
using System.Collections.Generic;

namespace _04._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }

                if (input[i] == ')')
                {
                    int start = indexes.Pop();

                    Console.WriteLine(input.Substring(start, i - start + 1));
                }
            }
        }
    }
}
