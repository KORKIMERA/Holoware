using Bizmonger.IO;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Data;

namespace Bizmonger.UILogic.Converters
{
    public class DirectoryToFilesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }

            try
            {
                var assumedDirectory = value as string;
                var directory = FileSystemHelpers.GetDirectory(assumedDirectory);

                var directoryExists = Directory.Exists(directory);

                if (!directoryExists)
                {
                    Directory.CreateDirectory(assumedDirectory);
                    Debug.Assert(Directory.Exists(assumedDirectory));
                    return null;
                }

                var filterOut = parameter as string;
                var extensions = filterOut.Split('|');

                var filePaths = Directory.EnumerateFiles(directory, "*.*").Where(f => extensions.Contains(Path.GetExtension(f).ToLower()));
                var filteredFiles = filePaths.Where(f => !f.ToLower().Contains(".vshost"));
                return filteredFiles;
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}