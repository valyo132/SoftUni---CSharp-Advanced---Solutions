using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDiration = int.Parse(Console.ReadLine());

            Queue<string> queueCars = new Queue<string>();

            int passedCars = 0;


            while (true)
            {
                string command = Console.ReadLine();

                int secondsAvalable = greenLightDuration;
                int windowSeconds = freeWindowDiration;

                if (command == "END")
                {
                    break;
                }

                if (command == "green")
                {
                    while (secondsAvalable > 0 && queueCars.Count > 0)
                    {
                        string car = queueCars.Dequeue();
                        secondsAvalable -= car.Count();

                        if (secondsAvalable >= 0)
                        {
                            passedCars++;
                        }
                        else
                        {
                            windowSeconds += secondsAvalable;

                            if (windowSeconds < 0)
                            {
                                Console.WriteLine($"A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[car.Length + windowSeconds]}.");
                                return;
                            }

                            passedCars++;
                        }
                    }
                }
                else
                {
                    queueCars.Enqueue(command);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
