using System;
using System.Collections.Generic;
using System.Linq;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public int Count { get { return Drones.Count; } }

        public List<Drone> Drones { get; set; }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
                return "Invalid drone.";
            else if (Count == Capacity)
                return "Airfield is full.";
            else if (drone.Range < 5 || drone.Range > 15)
                return "Invalid drone.";

            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            var drone = Drones.FirstOrDefault(x => x.Name == name);

            if (drone == null)
                return false;

            Drones.Remove(drone);
            return true;
        }

        public int RemoveDroneByBrand(string brand)
        {
            var drones = Drones.Where(x => x.Brand == brand).ToList();

            if (drones.Count == 0)
                return 0;

            Drones.RemoveAll(x => x.Brand == brand);
            return drones.Count;
        }

        public Drone FlyDrone(string name)
        {
            var drone = Drones.FirstOrDefault(x => x.Name == name);

            if (drone == null)
                return null;

            drone.Available = false;
            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
            => Drones.FindAll(x => x.Range >= range).ToList();

        public string Report()
            => $"Drones available at {Name}:" + Environment.NewLine +
                    string.Join(Environment.NewLine, Drones.Where(x => x.Available == true));
    }
}
