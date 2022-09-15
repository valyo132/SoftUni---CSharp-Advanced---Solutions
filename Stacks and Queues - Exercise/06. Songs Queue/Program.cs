using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputSongs = Console.ReadLine().Split(", ");

            Queue<string> songs = new Queue<string>(inputSongs);

            while (songs.Count > 0)
            {
                string command = Console.ReadLine();
                if (command == "Show")
                {
                    Console.WriteLine(String.Join(", ", songs));
                }

                if (command == "Play")
                {
                    songs.Dequeue();
                }

                if (command.Contains("Add"))
                {
                    string songToEnqueue = command.Substring(4, command.Length - 4);

                    if (!songs.Contains(songToEnqueue))
                    {
                        songs.Enqueue(songToEnqueue);
                    }
                    else
                    {
                        Console.WriteLine($"{songToEnqueue} is already contained!");
                    }
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
