using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Pokemon
    {
        public Pokemon(string name, string element, int healght)
        {
            Name = name;
            Element = element;
            Healght = healght;
        }

        public string Name { get; set; }

        public string Element { get; set; }

        public int Healght { get; set; }
    }
}
