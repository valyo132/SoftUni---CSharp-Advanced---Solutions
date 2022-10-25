using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }

        public List<Renovator> Renovators { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count { get { return Renovators.Count; } }

        public List<Renovator> PayRenovators(int days)
        {
            var validRenovators = Renovators.Where(x => x.Days >= days).ToList();

            return validRenovators;
        }

        public Renovator HireRenovator(string name)
        {
            if (Renovators.Any(x => x.Name == name))
            {
                var renovatorToHire = Renovators.First(x => x.Name == name);
                renovatorToHire.Hired = true;

                return renovatorToHire;
            }

            return null;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            if (Renovators.Any(x => x.Type == type))
            {
                var renovatorsToRemove = Renovators.FindAll(x => x.Type == type).ToList();
                Renovators.RemoveAll(x => x.Type == type);

                return renovatorsToRemove.Count;
            }

            return 0;
        }

        public bool RemoveRenovator(string name)
        {
            if (Renovators.Any(x => x.Name == name))
            {
                var renovatorToRemove = Renovators.FirstOrDefault(x => x.Name == name);
                Renovators.Remove(renovatorToRemove);

                return true;
            }

            return false;
        }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
                return "Invalid renovator's information.";
            if (this.Count >= this.NeededRenovators)
                return "Renovators are no more needed.";
            if (renovator.Rate > 350)
                return "Invalid renovator's rate.";
            this.Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {this.Project}:");

            foreach (var item in Renovators)
            {
                if (item.Hired == false)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            return sb.ToString().TrimEnd(); ;
        }
    }
}
