using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person person = new Person(name, age, town);
                list.Add(person);
            }

            int number = int.Parse(Console.ReadLine()) - 1;
            Person wantedPerson = list[number];

            int countOfMatches = 0;
            int numberOfNotEqualPeople = 0;
            int totalNumberOfPeople = list.Count;

            foreach (Person item in list)
            {
                if (wantedPerson.CompareTo(item) == 0)
                    countOfMatches++;
                else
                    numberOfNotEqualPeople++;
            }

            if (countOfMatches <= 1)
                Console.WriteLine("No matches");
            else
                Console.WriteLine($"{countOfMatches} {numberOfNotEqualPeople} {totalNumberOfPeople}");
        }
    }
}
