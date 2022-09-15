using System;
using System.Collections.Generic;
using System.Linq;

class Truck_Tour
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Queue<int[]> queue = new Queue<int[]>();

        for (int i = 0; i < n; i++)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            queue.Enqueue(input);
        }

        int startIndex = 0;

        while (true)
        {
            int totalLiters = 0;
            bool isComplete = true;

            foreach (int[] item in queue)
            {
                int liters = item[0];
                int distance = item[1];

                totalLiters += liters;

                if (totalLiters - distance < 0)
                {
                    startIndex++;
                    int[] currentPump = queue.Dequeue();
                    queue.Enqueue(currentPump);
                    isComplete = false;
                    break;
                }

                totalLiters -= distance;
            }

            if (isComplete)
            {
                Console.WriteLine(startIndex);
                break;
            }
        }
    }
}