namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            List<string> allLines = File.ReadLines(inputFilePath).ToList();

            using (var writer = new StreamWriter(outputFilePath))
            {
                int counter = 1;
                foreach (var line in allLines)
                {
                    int letters = 0;
                    int punctuationMarks = 0;


                    for (int i = 0; i < line.Length; i++)
                    {
                        if (char.IsLetter(line[i]))
                        {
                            letters++;
                        }
                        else if (char.IsPunctuation(line[i]))
                        {
                            punctuationMarks++;
                        }
                    }

                    string str = $"Line {counter}: {line} ({letters})({punctuationMarks})";
                    writer.Write(str + "\n");

                    counter++;
                }
            }
        }
    }
}
