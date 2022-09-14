using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfCars = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int passedCars = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                if (command == "green")
                {
                    for (int i = 0; i < countOfCars; i++)
                    {
                        if (cars.Count > 0)
                        {
                            string car = cars.Dequeue();

                            Console.WriteLine($"{car} passed!");
                            passedCars++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
