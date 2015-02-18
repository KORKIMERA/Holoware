using System;
using System.Windows.Data;

namespace Bismonger.UILogic.Converters
{
    public class HasTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var text = value as string;
            var minimalLength = int.Parse(parameter as string);

            if (text.Length >= minimalLength)
            {
                return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}