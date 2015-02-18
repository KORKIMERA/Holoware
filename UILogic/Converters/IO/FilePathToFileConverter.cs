using System;
using System.IO;
using System.Windows.Data;

namespace Bismonger.UILogic.Converters
{
    public class FilePathToFileConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var filePath = value as string;

            if (filePath == null)
            {
                return value;
            }

            var file = Path.GetFileName(filePath);

            return file;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}