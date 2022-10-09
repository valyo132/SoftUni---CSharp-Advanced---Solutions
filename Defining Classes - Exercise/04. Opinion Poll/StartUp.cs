using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            var allPeople = new List<Person>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                allPeople.Add(person);
            }

            allPeople = allPeople.Where(x => x.Age > 30).ToList();

            foreach (var person in allPeople.OrderBy(x => x.Name))
            {
                Console.WriteLine(person.Name + " - " + person.Age);
            }
        }
    }
}
