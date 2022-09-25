namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (var reader = new StreamReader(inputFilePath))
            {
                var result = new List<string>();

                char[] symbolsToReplace = new char[] { '-', ',', '.', '!', '?' };
                int counter = 0;

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (counter++ % 2 == 0)
                    {
                        foreach (var ch in symbolsToReplace)
                        {
                            line = line.Replace(ch, '@');
                        }

                        string[] allWords = line.Split();

                        string reversedString = "";

                        for (int i = allWords.Length - 1; i >= 0; i--)
                        {
                            reversedString += allWords[i] + " ";
                        }

                        result.Add(reversedString);
                    }
                }

                return string.Join("\n", result);
            }
        }
    }
}
