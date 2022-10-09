using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var allCars = new Dictionary<string, List<Car>>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];

                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);

                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);

                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);

                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Tire[] singleTires = new Tire[4]
                {
                    new Tire(tire1Age, tire1Pressure),
                    new Tire(tire2Age, tire2Pressure),
                    new Tire(tire3Age, tire3Pressure),
                    new Tire(tire4Age, tire4Pressure),
                };

                Car car = new Car(model, engine, cargo, singleTires);
                if (car.Cargo.Type == "fragile")
                {
                    if (!allCars.ContainsKey("fragile"))
                    {
                        allCars["fragile"] = new List<Car>();
                        allCars["fragile"].Add(car);
                    }
                    else
                    {
                        allCars["fragile"].Add(car);
                    }
                }
                else
                {
                    if (!allCars.ContainsKey("flammable"))
                    {
                        allCars["flammable"] = new List<Car>();
                        allCars["flammable"].Add(car);
                    }
                    else
                    {
                        allCars["flammable"].Add(car);
                    }
                }
            }

            string type = Console.ReadLine();

            if (type == "fragile")
            {
                foreach (var item in allCars.Where(x => x.Key == "fragile"))
                {
                    foreach (var car in item.Value)
                    {
                        if (car.Tires.Any(x => x.Preassure < 1))
                        {
                            Console.WriteLine(car.Model);
                        }
                    }
                }
            }
            else
            {
                foreach (var item in allCars.Where(x => x.Key == "flammable"))
                {
                    foreach (var car in item.Value)
                    {
                        if (car.Engine.Power > 250)
                        {
                            Console.WriteLine(car.Model);
                        }
                    }
                }
            }
        }
    }
}
