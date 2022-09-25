using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\words.txt";
            string textPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (var words = new StreamReader(wordsFilePath))
            {
                var result = new Dictionary<string, int>();

                string currLineWithWords;
                while ((currLineWithWords = words.ReadLine()) != null)
                {
                    string[] allWords = currLineWithWords.ToLower().Split(new char[] { ' ', '-', '.' }, System.StringSplitOptions.RemoveEmptyEntries).ToArray();

                    using (var text = new StreamReader(textFilePath))
                    {
                        string currTextLine;
                        while ((currTextLine = text.ReadLine()) != null)
                        {
                            string[] wordsForChecking = currTextLine.ToLower().Split(new char[] { ' ', '-', '.', ',', '?', '!' }, System.StringSplitOptions.RemoveEmptyEntries).ToArray();

                            for (int i = 0; i < allWords.Length; i++)
                            {
                                string currWord = allWords[i].ToLower();

                                if (!result.ContainsKey(currWord))
                                {
                                    result[currWord] = 0;
                                }

                                for (int j = 0; j < wordsForChecking.Length; j++)
                                {
                                    if (currWord == wordsForChecking[j])
                                    {
                                        result[currWord]++;
                                    }
                                }
                            }
                        }
                    }
                }
                using (var writer = new StreamWriter(outputFilePath))
                {
                    foreach (var word in result.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}

