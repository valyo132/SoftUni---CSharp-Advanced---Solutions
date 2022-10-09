using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tiresInfo = new List<Tire[]>();
            string input;

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tireYearAndPressure = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] singleTires = new Tire[4];

                int indexCounter = 0;
                for (int i = 0; i < 4; i++)
                {
                    int tireYear = int.Parse(tireYearAndPressure[indexCounter]);
                    indexCounter++;
                    double pressureValue = double.Parse(tireYearAndPressure[indexCounter]);
                    singleTires[i] = new Tire(tireYear, pressureValue);
                    indexCounter++;
                }
                tiresInfo.Add(singleTires);
            }

            var engineInfo = new List<Engine>();

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(engineInput[0]);
                double cubicCapacity = double.Parse(engineInput[1]);

                var engine = new Engine(horsePower, cubicCapacity);
                engineInfo.Add(engine);
            }

            var allCars = new List<Car>();

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = carInput[0];
                string model = carInput[1];
                int year = int.Parse(carInput[2]);
                double fuelQuantity = double.Parse(carInput[3]);
                double fuelConsumption = double.Parse(carInput[4]);
                int engineIndex = int.Parse(carInput[5]);
                int tiresIndex = int.Parse(carInput[6]);

                Engine wantedEngine = engineInfo[engineIndex];
                Tire[] wantedTires = tiresInfo[tiresIndex];

                var car = new Car(make, model, year, fuelQuantity, fuelConsumption, wantedEngine, wantedTires);
                allCars.Add(car);

                carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            List<Car> sprecialCars = allCars
                .FindAll(x => x.Year >= 2017
                           && x.Engine.HorsePower > 330
                           && x.Tires.Select(y => y.Pressure).Sum() >= 9
                           && x.Tires.Select(y => y.Pressure).Sum() <= 10);

            foreach (Car car in sprecialCars)
            {
                car.Drive(20);

                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
