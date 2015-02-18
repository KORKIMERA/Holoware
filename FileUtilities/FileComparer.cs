using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bizmonger.IO
{
    public class FileComparer
    {
        public static IEnumerable<string> GetUpdatedFiles(string sourceDirectory, string destinationDirectory)
        {
            var sourceFilePaths = Directory.EnumerateFiles(sourceDirectory).Where(f =>  Path.GetExtension(f).ToLower() == ".exe" || 
                                                                                        Path.GetExtension(f).ToLower() == ".dll" ||
                                                                                        Path.GetExtension(f).ToLower() == ".config");

            foreach (var filePath in sourceFilePaths)
            {
                var fileName = Path.GetFileName(filePath);
                var destinationFilePath = Path.Combine(destinationDirectory, fileName);

                if (!File.Exists(destinationFilePath))
                {
                    yield return filePath;
                    continue;
                }

                var sourceFileInfo = new FileInfo(filePath);
                var destinationFileInfo = new FileInfo(destinationFilePath);

                var isNewer = sourceFileInfo.LastWriteTime.CompareTo(destinationFileInfo.LastWriteTime) > 0;

                if (isNewer)
                {
                    yield return filePath;
                }
            }
        }
    }
}