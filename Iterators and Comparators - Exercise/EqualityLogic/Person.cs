using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Name, this.Age * 12435);
        }

        public override bool Equals(object? obj)
        {
            return obj is Person other && this.Name == other.Name && this.Age == other.Age;
        }

        public int CompareTo([AllowNull] Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }
            return result;
        }
    }
}
