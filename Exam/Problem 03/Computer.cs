using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Multiprocessor.Count; } }
        public List<CPU> Multiprocessor { get; set; }

        public void Add(CPU cpu)
        {
            if (Count < Capacity)
                Multiprocessor.Add(cpu);
        }

        public bool Remove(string brand)
        {
            var cpu = Multiprocessor.FirstOrDefault(x => x.Brand == brand);
            if (cpu == null)
                return false;

            Multiprocessor.Remove(cpu);
            return true;
        }

        public CPU MostPowerful()
            => Multiprocessor.OrderByDescending(x => x.Frequency).FirstOrDefault();

        public CPU GetCPU(string brand)
            => Multiprocessor.FirstOrDefault(x => x.Brand == brand);

        public string Report()
            => $"CPUs in the Computer {Model}:" + Environment.NewLine +
            string.Join(Environment.NewLine, Multiprocessor);
    }
}
