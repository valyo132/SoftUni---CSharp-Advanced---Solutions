using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"../../../input.txt";
            string outputFilePath = @"../../../output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            using (reader)
            {
                var writer = new StreamWriter(outputFilePath);
                using (writer)
                {
                    int counter = 0;

                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                            break;

                        if (counter % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                    }
                }
            }
        }
    }
}
