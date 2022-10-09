using System;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] nameAndAdress = Console.ReadLine().Split();
            string fullName = nameAndAdress[0] + " " + nameAndAdress[1];
            string adress = nameAndAdress[2];
            string town = "";
            if (nameAndAdress.Length == 5)
                town = nameAndAdress[3] + " " + nameAndAdress[4];
            else
                town = nameAndAdress[3];

            var pair = new Threeuple<string, string, string>(fullName, adress, town);
            Console.WriteLine(pair.ToString());

            string[] nameAndBeerIntereger = Console.ReadLine().Split();
            string name = nameAndBeerIntereger[0];
            int beer = int.Parse(nameAndBeerIntereger[1]);
            bool drunkOrNot = nameAndBeerIntereger[2] == "drunk" ? true : false;

            var beerDrunker = new Threeuple<string, int, bool>(name, beer, drunkOrNot);
            Console.WriteLine(beerDrunker.ToString());

            string[] intAndDouble = Console.ReadLine().Split();
            string bankACCholder = intAndDouble[0];
            double balance = double.Parse(intAndDouble[1]);
            string bankName = intAndDouble[2];

            var bank = new Threeuple<string, double, string>(bankACCholder, balance, bankName);
            Console.WriteLine(bank.ToString());
        }
    }
}
