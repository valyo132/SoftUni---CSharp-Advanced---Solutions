using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string, SortedSet<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Contains("Lumpawaroo"))
                {
                    break;
                }

                if (input.Contains("|"))
                {
                    string[] token = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string side = token[0];
                    string user = token[1];

                    if (!list.Values.Any(x => x.Contains(user)))
                    {
                        if (!list.ContainsKey(side))
                        {
                            list.Add(side, new SortedSet<string>());
                        }

                        list[side].Add(user);
                    }
                }
                else
                {
                    string[] token = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string user = token[0];
                    string side = token[1];

                    foreach (var sideUser in list)
                    {
                        if (sideUser.Value.Contains(user))
                        {
                            sideUser.Value.Remove(user);
                            break;
                        }
                        
                    }

                    if (!list.ContainsKey(side))
                    {
                        list.Add(side, new SortedSet<string>());
                    }

                    list[side].Add(user);

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            var orderedUsers = list.OrderByDescending(x => x.Value.Count)
                .ThenBy(s => s.Key);

            foreach (var side in orderedUsers.Where(x => x.Value.Count > 0))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                foreach (var name in side.Value)
                {
                    Console.WriteLine($"! {name}");
                }
            }
        }
    }
}
