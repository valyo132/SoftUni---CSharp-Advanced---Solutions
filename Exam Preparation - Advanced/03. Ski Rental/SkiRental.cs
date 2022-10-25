using System.Collections.Generic;
using System;
using System.Linq;

namespace SkiRental
{
    public class SkiRental
    {
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Data.Count; } }

        private List<Ski> data;

        public List<Ski> Data
        {
            get { return data; }
            set { data = value; }
        }


        public void Add(Ski ski)
        {
            if (Count < Capacity)
                Data.Add(ski);
        }

        public bool Remove(string manufacturer, string model)
        {
            var ski = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski == null)
                return false;

            Data.Remove(ski);
            return true;
        }

        public Ski GetNewestSki()
            => Data.OrderByDescending(x => x.Year).FirstOrDefault();

        public Ski GetSki(string manufacturer, string model)
            => Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

        public string GetStatistics()
        {
            return $"The skis stored in {Name}:" + Environment.NewLine +
                string.Join(Environment.NewLine, Data);
        }
    }
}
