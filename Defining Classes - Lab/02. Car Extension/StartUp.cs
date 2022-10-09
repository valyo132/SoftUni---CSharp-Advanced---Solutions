using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "Ferrari";
            car.Model = "F40";
            car.Year = 1992;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;

            car.Drive(2000);

            Console.WriteLine(car.WhoAmI());
        }
    }
}
