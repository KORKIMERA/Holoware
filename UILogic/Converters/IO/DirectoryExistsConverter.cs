using System;
using System.IO;
using System.Windows.Data;

namespace Bizmonger.UILogic.Converters
{
    public class DirectoryExistsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var text = value as string;
            return Directory.Exists(text);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}