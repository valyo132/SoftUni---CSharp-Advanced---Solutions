using System;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                Person newPerson = new Person(name, age);
                family.AddMember(newPerson);
            }

            var oldestMember = family.GetOldestMember();

            Console.WriteLine(oldestMember.Name + " " + oldestMember.Age);
        }
    }
}
