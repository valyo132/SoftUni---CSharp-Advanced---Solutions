using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int valueOfTheIntelligence = int.Parse(Console.ReadLine());

            Stack<int> stackBullets = new Stack<int>(bullets);
            Queue<int> queueLocks = new Queue<int>(locks);

            int totalMoneyForBullets = 0;

            int shots = 0;
            while (stackBullets.Count > 0)
            {
                shots++;

                int currBullet = stackBullets.Pop();
                int currLock = queueLocks.Peek();

                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");

                    queueLocks.Dequeue();

                    totalMoneyForBullets += bulletPrice;
                }
                else
                {
                    Console.WriteLine("Ping!");

                    totalMoneyForBullets += bulletPrice;
                }

                if (shots == gunBarrelSize && stackBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");

                    shots = 0;
                }

                if (queueLocks.Count == 0)
                {
                    Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${valueOfTheIntelligence - totalMoneyForBullets}");
                    return;
                }
            }

            Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
            return;
        }
    }
}
