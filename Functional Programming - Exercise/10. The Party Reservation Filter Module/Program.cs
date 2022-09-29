using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var namesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] tokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            var filters = new Dictionary<string, Predicate<string>>();

            while (tokens[0] != "Print")
            {
                string command = tokens[0];
                string condition = tokens[1];
                string value = tokens[2];
                string dicKey = condition + value;

                Predicate<string> conditionChecker = ConditionChecker(condition, value);
                if (command == "Add filter")
                    filters.Add(dicKey, conditionChecker);
                if (command == "Remove filter")
                    filters.Remove(dicKey);

                tokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            }

            Print(namesInput, filters);
        }

        static void Print(List<string> namesInput, Dictionary<string, Predicate<string>> filters)
        {
            foreach (var conditionChecker in filters.Values)
            {
                Func<List<string>, List<string>> applyFilter =
                    x => namesInput.Where(y => !conditionChecker(y)).ToList();

                namesInput = applyFilter(namesInput);
            }

            Console.WriteLine(String.Join(" ", namesInput));
        }

        public static Predicate<string> ConditionChecker(string condition, string value)
        {
            switch (condition)
            {
                case "Starts with":
                    return x => x.StartsWith(value);
                case "Ends with":
                    return x => x.EndsWith(value);
                case "Contains":
                    return x => x.Contains(value);
                case "Length":
                    return x => x.Length == int.Parse(value);
                default:
                    return x => x == null;
            }
        }
    }
}
