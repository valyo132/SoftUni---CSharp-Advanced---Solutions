using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var allCars = new HashSet<Car>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1km = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                allCars.Add(car);
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] token = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = token[0];
                string model = token[1];
                double distance = double.Parse(token[2]);

                if (action == "Drive" && allCars.Any(x => x.Model == model))
                {
                    var currCar = allCars.First(x => x.Model == token[1]);
                    currCar.Move(distance, currCar);
                }
            }

            foreach (var car in allCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
