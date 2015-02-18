using Bizmonger.IO;
using System;
using System.Windows.Data;

namespace Bizmonger.UILogic.Converters
{
    public class FilePathToContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var filePath = value as string;

            var content = filePath.GetContent();
            return content;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}