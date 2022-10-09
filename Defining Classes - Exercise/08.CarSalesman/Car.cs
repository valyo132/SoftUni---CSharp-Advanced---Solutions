using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, string color)
        {
            Model = model;
            Engine = engine;
            Color = color;
        }

        public Car(string model, Engine engine, int weight)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
        }

        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public void ToString()
        {
            Console.WriteLine($"{this.Model}:");
            Engine.ToString();
            if (this.Weight != 0)
                Console.WriteLine($"  Weight: {this.Weight}");
            else
                Console.WriteLine($"  Weight: n/a");
            if (this.Color != null)
                Console.WriteLine($"  Color: {this.Color}");
            else
                Console.WriteLine($"  Color: n/a");
        }
    }
}
