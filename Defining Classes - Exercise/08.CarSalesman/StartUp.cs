using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> allEngines = new List<Engine>();
            List<Car> allCars = new List<Car>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] engineInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = TakeEngineInfo(engineInput);
                allEngines.Add(engine);
            }

            number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = TakeCarInfo(allEngines, carInput);
                allCars.Add(car);
            }

            foreach (var car in allCars)
            {
                car.ToString();
            }
        }

        private static Car TakeCarInfo(List<Engine> allEngines, string[] carInput)
        {
            if (carInput.Length == 4)
            {
                string model = carInput[0];
                Engine carEngine = allEngines.First(x => x.Model == carInput[1]);
                int weight = int.Parse(carInput[2]);
                string color = carInput[3];

                Car car = new Car(model, carEngine, weight, color);
                return car;
            }
            else if (carInput.Length == 3)
            {
                string model = carInput[0];
                Engine carEngine = allEngines.First(x => x.Model == carInput[1]);
                int weight;

                bool success = int.TryParse(carInput[2], out weight);
                if (!success)
                {
                    string color = carInput[2];
                    Car car = new Car(model, carEngine, color);
                    return car;
                }
                else
                {
                    Car car = new Car(model, carEngine, weight);
                    return car;
                }
            }
            else
            {
                string model = carInput[0];
                Engine carEngine = allEngines.First(x => x.Model == carInput[1]);

                Car car = new Car(model, carEngine);
                return car;
            }
        }

        private static Engine TakeEngineInfo(string[] engineInput)
        {
            if (engineInput.Length == 4)
            {
                string model = engineInput[0];
                int power = int.Parse(engineInput[1]);
                int displacement = int.Parse(engineInput[2]);
                string efficiency = engineInput[3];

                Engine engine = new Engine(model, power, displacement, efficiency);
                return engine;
            }
            else if (engineInput.Length == 3)
            {
                string model = engineInput[0];
                int power = int.Parse(engineInput[1]);
                int displacement;

                bool success = int.TryParse(engineInput[2], out displacement);
                if (!success)
                {
                    string efficiency = engineInput[2];
                    Engine engine = new Engine(model, power, efficiency);
                    return engine;
                }
                else
                {
                    Engine engine = new Engine(model, power, displacement);
                    return engine;
                }
            }
            else
            {
                string model = engineInput[0];
                int power = int.Parse(engineInput[1]);

                Engine engine = new Engine(model, power);
                return engine;
            }
        }
    }
}
