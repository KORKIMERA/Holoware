using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Bismonger.IO
{
    public static class Extensions
    {
        public static string GetContent(this string filePath)
        {
            var stringbuilder = new StringBuilder();

            string[] file = File.ReadAllLines(filePath);

            foreach (string line in file)
            {
                stringbuilder.Append(line + "\r\n");
            }

            return stringbuilder.ToString();
        }

        public static void SearchAndReplace(this IEnumerable<string> filePaths, string searchCriteria, string replacementValue, List<string> modifiedFiles, out int replacementCount)
        {
            var totalCount = new List<int>();
            replacementCount = 0;

            foreach (var filePath in filePaths)
            {
                SearchAndReplace(filePath, searchCriteria, replacementValue, modifiedFiles, replacementCount, totalCount);
            }

            replacementCount = totalCount.Sum();
        }

        public static void SearchAndReplace(this string filePath, string searchCriteria, string replacementValue, List<string> modifiedFiles, int replacementCount, List<int> totalCount)
        {
            string[] file = File.ReadAllLines(filePath);

            var content = file.SearchAndReplace(searchCriteria, replacementValue, out replacementCount);

            if (replacementCount > 0)
            {
                modifiedFiles.Add(filePath);
                totalCount.Add(replacementCount);
            }

            File.WriteAllText(filePath, content);
        }

        public static string SearchAndReplace(this string[] file, string searchCriteria, string replacementValue, out int replacementCount)
        {
            var stringbuilder = new StringBuilder();
            replacementCount = 0;

            foreach (string line in file)
            {
                if (line.ToUpper().Contains(searchCriteria.ToUpper()))
                {
                    var updatedLine = Regex.Replace(line, Regex.Escape(searchCriteria), replacementValue, RegexOptions.IgnoreCase);

                    stringbuilder.Append(updatedLine + "\r\n");
                    replacementCount++;
                    continue;
                }

                else
                {
                    stringbuilder.Append(line + "\r\n");
                }
            }

            return stringbuilder.ToString();
        }
    }
}