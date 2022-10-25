using System;
using System.Collections.Generic;
using System.Linq;

namespace TheRace
{
    public class Race
    {
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return Data.Count; } }

        private List<Racer> data;

        public List<Racer> Data
        {
            get { return data; }
            set { data = value; }
        }

        public void Add(Racer Racer)
        {
            if (Count < Capacity)
                Data.Add(Racer);
        }

        public bool Remove(string name)
        {
            var racer = Data.FirstOrDefault(x => x.Name == name);
            if (racer == null)
                return false;

            Data.Remove(racer);
            return true;
        }

        public Racer GetOldestRacer()
            => Data.OrderByDescending(x => x.Age).FirstOrDefault();

        public Racer GetRacer(string name)
            => Data.FirstOrDefault(x => x.Name == name);

        public Racer GetFastestRacer()
            => Data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();

        public string Report()
        {
            return $"Racers participating at {Name}:" + Environment.NewLine +
                string.Join(Environment.NewLine, Data);
        }

    }
}
