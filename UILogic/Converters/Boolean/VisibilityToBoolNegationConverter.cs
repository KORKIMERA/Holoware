using System;
using System.Windows;
using System.Windows.Data;

namespace Bismonger.UILogic.Converters
{
    public class VisibilityToBoolNegationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var loaded = (bool)value;

            if (loaded)
            {
                return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}