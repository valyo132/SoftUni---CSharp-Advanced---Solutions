using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            Capacity = capacity;
            Data = new List<Pet>();
        }

        public int Capacity { get; set; }
        public int Count { get { return Data.Count; } }
        private List<Pet> data;

        public List<Pet> Data
        {
            get { return data; }
            set { data = value; }
        }

        public void Add(Pet pet)
        {
            if (Count < Capacity)
                Data.Add(pet);
        }

        public bool Remove(string name)
        {
            var pet = Data.FirstOrDefault(x => x.Name == name);
            if (pet == null)
                return false;

            Data.Remove(pet);
            return true;
        }

        public Pet GetPet(string name, string owner)
            => Data.FirstOrDefault(x => x.Name == name && x.Owner == owner);

        public Pet GetOldestPet()
            => Data.OrderByDescending(x => x.Age).FirstOrDefault();

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var item in Data)
            {
                sb.AppendLine($"Pet {item.Name} with owner: {item.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
