using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> allGuests = new HashSet<string>();
            HashSet<string> peopleAtTheParty = new HashSet<string>();

            while (true)
            {
                string guest = Console.ReadLine();

                if (guest == "END")
                {
                    break;
                }

                if (guest == "PARTY")
                {
                    while (true)
                    {
                        guest = Console.ReadLine();

                        if (guest == "END")
                        {
                            break;
                        }

                        peopleAtTheParty.Add(guest);
                    }

                    break;
                }

                allGuests.Add(guest);

            }

            int counter = 0;
            HashSet<string> didntCome = new HashSet<string>();

            foreach (var name in allGuests)
            {
                if (!peopleAtTheParty.Contains(name))
                {
                    counter++;

                    didntCome.Add(name);
                }
            }

            HashSet<string> VIP = didntCome.Where(x => Char.IsDigit(x[0])).ToHashSet();
            HashSet<string> regular = didntCome.Where(x => !Char.IsDigit(x[0])).ToHashSet();


            Console.WriteLine(counter);
            foreach (var name in VIP)
            {
                Console.WriteLine(name);
            }
            foreach (var name in regular)
            {
                Console.WriteLine(name);
            }
        }
    }
}
