using System;
using System.Collections.Generic;
using System.Linq;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }

        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return Fish.Count; } }

        public List<Fish> Fish { get; set; }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType))
                return "Invalid fish.";
            else if (Capacity == Count)
                return "Fishing net is full.";
            else if (fish.Weight <= 0 || fish.Length <= 0)
                return "Invalid fish.";

            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            if (!Fish.Any(x => x.Weight == weight))
                return false;

            var fish = Fish.Find(x => x.Weight == weight);
            Fish.Remove(fish);
            return true;
        }

        public Fish GetFish(string fishType)
            => Fish.Find(x => x.FishType == fishType);

        public Fish GetBiggestFish()
            => Fish.OrderByDescending(x => x.Length).First();

        public string Report()
        {
            return $"Into the {Material}:" + Environment.NewLine +
                string.Join(Environment.NewLine, Fish.OrderByDescending(x => x.Length));
        }
    }
}
