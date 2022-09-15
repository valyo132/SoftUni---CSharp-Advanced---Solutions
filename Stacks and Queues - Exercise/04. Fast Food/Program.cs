using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            int[] allOrdersQuantity = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(allOrdersQuantity);

            int max = int.MinValue;
            foreach (var num in orders)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            Console.WriteLine(max);

            while (orders.Count > 0)
            {
                int currOrderQuantity = orders.Peek();

                if (quantity >= currOrderQuantity)
                {
                    orders.Dequeue();

                    quantity -= currOrderQuantity;
                }
                else
                {
                    Console.WriteLine("Orders left: " + String.Join(" ", orders));
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
