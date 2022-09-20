using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(", ");

                if (command[0] == "END")
                {
                    break;
                }

                if (command[0] == "IN")
                {
                    parking.Add(command[1]);
                }
                else
                {
                    parking.Remove(command[1]);
                }
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (var item in parking)
            {
                Console.WriteLine(item);
            }
        }
    }
}
