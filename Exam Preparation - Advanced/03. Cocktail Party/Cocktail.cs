namespace CocktailParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel { get { return this.Ingredients.Select(i => i.Alcohol).Sum(); } }

        public List<Ingredient> Ingredients { get; set; }

        public void Add(Ingredient ingredient)
        {
            if (Ingredients.Count == 0)
            {
                Ingredients.Add(ingredient);
            }
            else if (Ingredients.Any(x => x.Name != ingredient.Name) && Ingredients.Count < Capacity && ingredient.Alcohol <= MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            var cocktail = Ingredients.FirstOrDefault(x => x.Name == name);
            if (cocktail == null)
                return false;

            Ingredients.Remove(cocktail);
            return true;
        }

        public Ingredient FindIngredient(string name)
            => Ingredients.FirstOrDefault(x => x.Name == name);

        public Ingredient GetMostAlcoholicIngredient()
            => Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();

        public string Report()
        {
            return $"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}" + Environment.NewLine +
                string.Join(Environment.NewLine, Ingredients);
        }
    }
}
