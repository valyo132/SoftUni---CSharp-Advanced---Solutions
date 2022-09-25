using System;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVAT =
               x => x * 1.2;

            double[] numbers = Console.ReadLine().Split(", ").Select(double.Parse).ToArray();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{addVAT(num):f2}");
            }
        }
    }
}
