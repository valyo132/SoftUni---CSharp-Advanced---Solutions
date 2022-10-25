using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] taskInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> tasks = new Stack<int>(taskInput);

            int[] threadsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> threads = new Queue<int>(threadsInput);

            int goalTaks = int.Parse(Console.ReadLine());
            int killer = 0;
            int killedTask = 0;
            bool taskKilled = false;

            while (tasks.Count > 0 && threads.Count > 0 && taskKilled == false)
            {
                int currThread = threads.Peek();
                int currTask = tasks.Peek();

                if (currTask == goalTaks)
                {
                    killer = currThread;
                    killedTask = currTask;
                    taskKilled = true;
                    break;
                }
                else if (currThread >= currTask)
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {killer} killed task {goalTaks}");
            Console.WriteLine(String.Join(" ", threads));
        }
    }
}
