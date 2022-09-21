using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Statistics")
                {
                    break;
                }

                string name = input[0];
                string command = input[1];
                string secondName = input[2];

                if (!logger.ContainsKey(name) && command == "joined")
                {
                    logger[name] = new Dictionary<string, HashSet<string>>();
                    logger[name]["followers"] = new HashSet<string>();
                    logger[name]["following"] = new HashSet<string>();
                }
                else
                {
                    if (name != secondName)
                    {
                        if (logger.ContainsKey(secondName) && logger.ContainsKey(name))
                        {
                            logger[name]["following"].Add(secondName);
                            logger[secondName]["followers"].Add(name);
                        }
                    }
                }
            }

            logger = logger.OrderByDescending(x => x.Value["followers"].Count).ThenBy(s => s.Value["following"].Count)
                .ToDictionary(x => x.Key, s => s.Value);

            Console.WriteLine($"The V-Logger has a total of {logger.Count} vloggers in its logs.");

            int counter = 1;
            foreach (var vlogger in logger)
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                counter++;
            }
        }
    }
}
