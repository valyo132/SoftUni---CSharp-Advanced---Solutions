namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var database = new SortedDictionary<string, SortedDictionary<string, double>>();

            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (var file in files)
            {
                DirectoryInfo dir = new DirectoryInfo(file);
                string name = dir.Name;
                string extension = dir.Extension;
                FileInfo info = new FileInfo(file);
                double size = info.Length / 1024;

                if (!database.ContainsKey(extension))
                {
                    database[extension] = new SortedDictionary<string, double>();
                    database[extension].Add(name, size);
                }
                else
                {
                    database[extension].Add(name, size);
                }
            }

            var stringForReport = "";

            foreach (var ext in database.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                stringForReport += ext.Key + "\n";

                foreach (var file in ext.Value.OrderBy(x => x.Value))
                {
                    stringForReport += $"--{file.Key} - {file.Value:f3}kb\n";
                }
            }

            return stringForReport;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string reportPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            using (var writer = new StreamWriter(reportPath + reportFileName))
            {
                writer.Write(textContent);
            }
        }
    }
}
