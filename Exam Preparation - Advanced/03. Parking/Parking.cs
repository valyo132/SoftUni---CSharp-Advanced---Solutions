using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Data.Count; } }
        private List<Car> data;

        public List<Car> Data
        {
            get { return data; }
            set { data = value; }
        }

        public void Add(Car car)
        {
            if (Count < Capacity)
                Data.Add(car);
        }

        public bool Remove(string manufacturer, string model)
        {
            var car = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (car == null)
                return false;

            Data.Remove(car);
            return true;
        }

        public Car GetLatestCar()
            => Data.OrderByDescending(x => x.Year).FirstOrDefault();

        public Car GetCar(string manufacturer, string model)
            => Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

        public string GetStatistics()
            => $"The cars are parked in {Type}:" + Environment.NewLine +
            string.Join(Environment.NewLine, Data);
    }
}
