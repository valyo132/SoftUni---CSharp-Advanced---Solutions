using System;

namespace Drones
{
    public class Drone
    {
        public Drone(string name, string brand, int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
        }

        public string Name { get; set; }
        public string Brand { get; set; }
        public int Range { get; set; }
        public bool Available { get; set; } = true;

        public override string ToString()
            => $"Drone: {Name}" + Environment.NewLine +
               $"Manufactured by: {Brand}" + Environment.NewLine +
               $"Range: {Range} kilometers";
    }
}
