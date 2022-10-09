using System;
using System.Collections.Generic;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] nameAndAdress = Console.ReadLine().Split();
            string fullName = nameAndAdress[0] + " " + nameAndAdress[1];
            string adress = nameAndAdress[nameAndAdress.Length - 1];

            Tuple<string, string> pair = new Tuple<string, string>(fullName, adress);
            Console.WriteLine(pair.ToString());

            string[] nameAndBeerIntereger = Console.ReadLine().Split();
            string name = nameAndBeerIntereger[0];
            int beer = int.Parse(nameAndBeerIntereger[1]);

            Tuple<string, int> beerDrunker = new Tuple<string, int>(name, beer);
            Console.WriteLine(beerDrunker.ToString());

            string[] intAndDouble = Console.ReadLine().Split();
            int number = int.Parse(intAndDouble[0]);
            double floatNumber = double.Parse(intAndDouble[1]);

            Tuple<int, double> numbers = new Tuple<int, double>(number, floatNumber);
            Console.WriteLine(numbers.ToString());
        }
    }
}
