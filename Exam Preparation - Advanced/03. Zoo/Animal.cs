namespace Zoo
{
    public class Animal
    {
        public Animal(string species, string diet, double weight, double lenght)
        {
            Species = species;
            Diet = diet;
            Weight = weight;
            Length = lenght;
        }

        public string Species { get; set; }
        public string Diet { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }

        public override string ToString()
        {
            return $"The {this.Species} is a {this.Diet} and weighs {this.Weight} kg.";
        }
    }
}
