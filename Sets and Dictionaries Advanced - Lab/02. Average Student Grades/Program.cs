using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfInputs = int.Parse(Console.ReadLine());

            var scholo = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < countOfInputs; i++)
            {
                string[] newGrade = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = newGrade[0];
                decimal grade = decimal.Parse(newGrade[1]);

                if (!scholo.ContainsKey(name))
                {
                    scholo[name] = new List<decimal>();
                    scholo[name].Add(grade);
                }
                else
                {
                    scholo[name].Add(grade);
                }
            }

            foreach (var student in scholo)
            {
                var avarageGrade = student.Value.Average();

                Console.Write($"{student.Key} -> ");

                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {avarageGrade:f2})");
            }
        }
    }
}
