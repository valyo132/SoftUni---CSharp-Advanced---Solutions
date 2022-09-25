using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = ReadPeopleInput();

            string condition = Console.ReadLine();
            int wantedAgeForCondition = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = FilterFunction(condition, wantedAgeForCondition);
            people = people.Where(filter).ToList();

            string wantedinformationToPrint = Console.ReadLine();
            Action<Person> formatPeople = FormatingPeople(wantedinformationToPrint);
            PrintPeople(people, formatPeople);
        }

        private static void PrintPeople(List<Person> database, Action<Person> formatter)
        {
            foreach (var person in database)
                formatter(person);
        }

        static Action<Person> FormatingPeople(string wantedFormat)
        {
            if (wantedFormat == "name age")
                return x => Console.WriteLine($"{x.Name} - {x.Age}");
            if (wantedFormat == "name")
                return x => Console.WriteLine($"{x.Name}");
            if (wantedFormat == "age")
                return x => Console.WriteLine($"{x.Age}");

            return null;
        }

        static Func<Person, bool> FilterFunction(string condition, int wantedAgeForCondition)
        {
            if (condition == "older")
                return x => x.Age >= wantedAgeForCondition;
            else if (condition == "younger")
                return x => x.Age <= wantedAgeForCondition;

            return null;
        }

        private static List<Person> ReadPeopleInput()
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> database = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                string name = input[0];
                int age = int.Parse(input[1]);

                database.Add(new Person(name, age));
            }

            return database;
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
    }
}
