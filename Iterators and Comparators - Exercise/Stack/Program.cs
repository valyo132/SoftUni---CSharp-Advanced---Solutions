using System;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new Stack<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (tokens[0])
                {
                    case "Push":
                        string[] elements = tokens.Skip(1).ToArray();
                        list.Push(elements);
                        break;
                    case "Pop":
                        list.Pop();
                        break;
                }
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
