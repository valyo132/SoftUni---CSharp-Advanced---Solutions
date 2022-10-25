namespace BakeryOpenning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bakery
    {
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Data.Count; } }
        private List<Employee> data;

        public List<Employee> Data
        {
            get { return data; }
            set { data = value; }
        }

        public void Add(Employee employee)
        {
            if (Count < Capacity)
                Data.Add(employee);
        }

        public bool Remove(string name)
        {
            var person = Data.FirstOrDefault(x => x.Name == name);
            if (person == null)
                return false;

            Data.Remove(person);
            return true;
        }

        public Employee GetOldestEmployee()
            => Data.OrderByDescending(x => x.Age).FirstOrDefault();

        public Employee GetEmployee(string name)
            => Data.FirstOrDefault(x => x.Name == name);

        public string Report()
            => $"Employees working at Bakery {Name}:" + Environment.NewLine +
                string.Join(Environment.NewLine, Data);
    }
}
