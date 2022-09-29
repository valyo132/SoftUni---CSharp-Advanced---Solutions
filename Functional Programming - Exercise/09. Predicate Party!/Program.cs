using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] inptCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (inptCommand[0] != "Party!")
            {
                string action = inptCommand[0];
                string condition = inptCommand[1];
                string value = inptCommand[2];

                Predicate<string> conditionChecker = ConditionChecker(condition, value);

                if (action == "Remove")
                {
                    names.RemoveAll(ConditionChecker(condition, value));
                }
                else
                {
                    var peopleToDouble = names.FindAll(ConditionChecker(condition, value)).ToList();

                    int index = names.FindIndex(ConditionChecker(condition, value));

                    if (index >= 0)
                    {
                        names.InsertRange(index, peopleToDouble);
                    }
                }

                inptCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            printer(names);
        }

        static Predicate<string> ConditionChecker(string condition, string value)
        {
            switch (condition)
            {
                case "StartsWith":
                    return x => x.StartsWith(value);
                case "EndsWith":
                    return x => x.EndsWith(value);
                case "Length":
                    return x => x.Length == int.Parse(value);
                default:
                    return x => x == null;
            }
        }

        static Action<List<string>> printer = (names) =>
        {
            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        };
    }
}
