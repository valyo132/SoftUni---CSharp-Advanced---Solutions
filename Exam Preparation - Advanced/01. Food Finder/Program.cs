using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>()
            {
                "pear",
                "flour", 
                "pork", 
                "olive"
            };

            Dictionary<char, int> letters = new Dictionary<char, int>();

            char[] vowelsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            Queue<char> vowels = new Queue<char>(vowelsInput);

            char[] constantsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            Stack<char> constants = new Stack<char>(constantsInput);

            while (vowels.Count > 0 && constants.Count > 0)
            {
                char currVowel = vowels.Dequeue();
                char currConstant = constants.Pop();

                if (!letters.ContainsKey(currVowel))
                    letters[currVowel] = 1;
                else
                    letters[currVowel]++;

                if (!letters.ContainsKey(currConstant))
                    letters[currConstant] = 1;
                else
                    letters[currConstant]++;

                vowels.Enqueue(currVowel);
            }

            List<string> wordsToPrint = new List<string>();

            foreach (var word in words)
            {
                char[] array = word.ToCharArray();
                int count = 0;

                foreach (var letter in array)
                {
                    if (letters.ContainsKey(letter))
                    {
                        count++;
                        letters[letter]--;
                    }
                }

                if (count == word.Length)
                {
                    wordsToPrint.Add(word);
                }
            }

            Console.WriteLine($"Words found: {wordsToPrint.Count}");
            Console.WriteLine(String.Join("\n", wordsToPrint));
        }
    }
}
