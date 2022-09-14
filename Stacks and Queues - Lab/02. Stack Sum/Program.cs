using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            while (true)
            {
                string[] command = Console.ReadLine().ToLower().Split();
                if (command[0] == "end")
                {
                    break;
                }

                if (command[0] == "add")
                {
                    int firstNum = int.Parse(command[1]);
                    int secondNum = int.Parse(command[2]);
                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }

                if (command[0] == "remove")
                {
                    int count = int.Parse(command[1]);
                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
