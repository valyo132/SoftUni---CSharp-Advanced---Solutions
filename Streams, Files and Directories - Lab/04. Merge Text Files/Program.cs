using System.Collections.Generic;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\input1.txt";
            var secondInputFilePath = @"..\..\..\input2.txt";
            var outputFilePath = @"..\..\..\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var result = new List<string>();

            using (var firstFile = new StreamReader(firstInputFilePath))
            using (var secondFile = new StreamReader(secondInputFilePath))
            {
                string firstNumber;
                string secondNumber;
                while (true)
                {
                    firstNumber = firstFile.ReadLine();

                    if (firstNumber == null)
                    {
                        while ((secondNumber = secondFile.ReadLine()) != null)
                        {
                            result.Add(secondNumber);
                        }
                        break;
                    }

                    secondNumber = secondFile.ReadLine();

                    if (secondNumber == null)
                    {
                        while ((firstNumber = firstFile.ReadLine()) != null)
                        {
                            result.Add(firstNumber);
                        }
                        break;
                    }

                    result.Add(firstNumber);
                    result.Add(secondNumber);
                }
            }

            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var number in result)
                {
                    writer.WriteLine(number);
                }
            }

        }
    }
}
