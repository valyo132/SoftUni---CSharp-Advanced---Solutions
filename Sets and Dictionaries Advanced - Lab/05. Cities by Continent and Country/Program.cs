using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfInput = int.Parse(Console.ReadLine());

            var listOfCountries = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < countOfInput; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!listOfCountries.ContainsKey(continent))
                {
                    listOfCountries[continent] = new Dictionary<string, List<string>>();
                    listOfCountries[continent].Add(country, new List<string>());
                    listOfCountries[continent][country].Add(city);
                }
                else
                {
                    if (listOfCountries[continent].ContainsKey(country))
                    {
                        listOfCountries[continent][country].Add(city);
                    }
                    else
                    {
                        listOfCountries[continent].Add(country, new List<string>());
                        listOfCountries[continent][country].Add(city);
                    }
                }
            }

            foreach (var continent in listOfCountries)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.Write(country.Key + " -> " );

                    List<string> cities = new List<string>();
                    foreach (var city in country.Value)
                    {
                        cities.Add(city);
                    }

                    Console.WriteLine(String.Join(", ", cities));
                }
            }
        }
    }
}
