using System.IO;
using System.Text.RegularExpressions;

namespace Bismonger.IO
{
    public class FileSystemHelpers
    {
        public static string GetDirectory(string assumedDirectory)
        {
            if (assumedDirectory == null)
            {
                return assumedDirectory;
            }

            var defaultDirectoryExists = Directory.Exists(assumedDirectory);

            string directory = null;

            if (!defaultDirectoryExists)
            {
                directory = Regex.Replace(assumedDirectory, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ").ToLower();

                var speculatedDirectoryExists = Directory.Exists(directory);

                if (!speculatedDirectoryExists)
                {
                    return null;
                }
            }
            else
            {
                directory = assumedDirectory;
            }

            return directory;
        }
    }
}