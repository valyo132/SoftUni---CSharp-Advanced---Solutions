using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private readonly List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals { get { return animals; } }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrEmpty(animal.Species))
                return "Invalid animal species.";
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
                return "Invalid animal diet.";
            if (Animals.Count >= Capacity)
                return "The zoo is full.";

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            return Animals.RemoveAll(x => x.Species == species);
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return this.Animals.FindAll(x => x.Diet == diet).ToList();
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.Find(x => x.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = Animals.Where(x => x.Length >= minimumLength && x.Length <= maximumLength).Count();

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
