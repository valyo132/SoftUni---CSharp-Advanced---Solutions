using System.Collections.Generic;
using System.Linq;
using System;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count { get { return Participants.Count; } }

        public List<Car> Participants { get; set; }

        public void Add(Car car)
        {
            if (!Participants.Any(x => x.LicensePlate == car.LicensePlate) && car.HorsePower <= MaxHorsePower && Count < Capacity)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            var car = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (car == null)
                return false;

            Participants.Remove(car);
            return true;
        }

        public Car FindParticipant(string licensePlate)
            => Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);

        public Car GetMostPowerfulCar()
            => Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();

        public string Report()
        {
            return $"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})" + Environment.NewLine +
                string.Join(Environment.NewLine, Participants);
        }
    }
}
