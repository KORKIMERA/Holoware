using System;
using System.IO;
using System.Windows.Data;

namespace Bizmonger.UILogic.Converters
{
    public class TextTruncationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var filePath = value as string;
            var fileName = Path.GetFileName(filePath);

            return fileName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
