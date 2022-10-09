using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            Capacity = capacity;
            Cars = new List<Car>();
        }

        public int Count { get { return Cars.Count; } }

        private List<Car> cars;

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public string AddCar(Car car)
        {
            if (Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
                return "Car with that registration number, already exists!";

            if (this.Cars.Count == capacity)
                return "Parking is full!";

            Cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public Car GetCar(string registrationNumber)
            => Cars.Find(x => x.RegistrationNumber == registrationNumber);

        public string RemoveCar(string registrationNumber)
        {
            if (Cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                var carToRemove = Cars.Find(x => x.RegistrationNumber == registrationNumber);

                Cars.Remove(carToRemove);
                return $"Successfully removed {registrationNumber}";
            }

            return "Car with that registration number, doesn't exist!";
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var number in RegistrationNumbers)
                RemoveCar(number);
        }
    }
}
