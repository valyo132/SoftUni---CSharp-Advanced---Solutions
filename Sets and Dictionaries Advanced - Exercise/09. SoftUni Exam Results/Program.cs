using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var results = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();

            while (true)
            {
                string[] command = Console.ReadLine().Split("-");

                if (command[0] == "exam finished")
                {
                    break;
                }

                if (command[1] == "banned")
                {
                    results.Remove(command[0]);
                    continue;
                }

                string name = command[0];
                string language = command[1];
                int points = int.Parse(command[2]);

                if (!results.ContainsKey(name))
                {
                    results[name] = 0;
                    results[name] = points;
                }
                if (points > results[name])
                {
                    results[name] = points;
                }

                if (!submissions.ContainsKey(language))
                {
                    submissions[language] = 1;
                }
                else
                {
                    submissions[language]++;
                }
            }

            results = results.OrderByDescending(x => x.Value)
                .ThenBy(s => s.Key)
                .ToDictionary(s => s.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var name in results)
            {
                Console.WriteLine($"{name.Key} | {name.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var lang in submissions.OrderByDescending(x => x.Value).ThenBy(s => s.Key))
            {
                Console.WriteLine($"{lang.Key} - {lang.Value}");
            }
        }
    }
}
