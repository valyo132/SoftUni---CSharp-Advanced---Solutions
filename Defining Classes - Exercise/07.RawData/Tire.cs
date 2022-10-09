using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        public Tire(int age, double preassure)
        {
            Age = age;
            Preassure = preassure;
        }

        public int Age { get; set; }

        public double Preassure { get; set; }
    }
}
