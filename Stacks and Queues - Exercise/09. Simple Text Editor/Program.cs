using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfCommands = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();

            Stack<string> text = new Stack<string>();
            text.Push(builder.ToString());

            for (int i = 0; i < countOfCommands; i++)
            {
                string[] commandInput = Console.ReadLine().Split();

                switch (commandInput[0])
                {
                    case "1":
                        string stringToAppend = commandInput[1];

                        builder.Append(stringToAppend);

                        text.Push(builder.ToString());
                        break;
                    case "2":
                        int countToErase = int.Parse(commandInput[1]);

                        builder.Remove(builder.Length - countToErase, countToErase);
                        text.Push(builder.ToString());
                        break;
                    case "3":
                        int indexToReturn = int.Parse(commandInput[1]) - 1;

                        Console.WriteLine(builder[indexToReturn]);
                        break;
                    case "4":
                        text.Pop();
                        builder = new StringBuilder();
                        builder.Append(text.Peek());
                        break;
                }
            }
        }
    }
}
