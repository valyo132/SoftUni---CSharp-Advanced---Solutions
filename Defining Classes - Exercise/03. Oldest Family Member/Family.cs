using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }

        private List<Person> people;

        public List<Person> People
        {
            get { return people; }
            set { people = value; }
        }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            int max = int.MinValue;

            foreach (var member in People)
            {
                if (member.Age > max)
                {
                    max = member.Age;
                }
            }

            return People.First(x => x.Age == max);
        }
    }
}
