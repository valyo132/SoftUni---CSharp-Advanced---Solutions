using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            var items = new List<double>();

            int number = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < number; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box = new Box<double>(input);
                items.Add(input);
            }

            double itemToCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Count(items, itemToCompare));
        }
    }
}
