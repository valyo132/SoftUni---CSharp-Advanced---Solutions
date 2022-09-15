using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> values = new Stack<int>(input);

            int capacityOfRack = int.Parse(Console.ReadLine());

            int currStackSum = 0;
            int ussedStacks = 0;
            while (values.Count > 0)
            {
                if (values.Count == 1)
                {
                    ussedStacks++;

                    break;
                }

                int firstNum = values.Pop();
                int secondNum = values.Pop();

                if (firstNum + secondNum < capacityOfRack)
                {
                    currStackSum += firstNum + secondNum;

                    values.Push(firstNum + secondNum);
                }
                else if (firstNum + secondNum > capacityOfRack)
                {
                    values.Push(secondNum);

                    ussedStacks++;

                    currStackSum = 0;
                }
                else
                {
                    ussedStacks++;

                    currStackSum = 0;
                }
            }

            Console.WriteLine(ussedStacks);
        }
    }
}
