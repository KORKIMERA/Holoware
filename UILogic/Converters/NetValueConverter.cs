using System;
using System.Windows.Data;
using System.Windows.Media;

namespace Bizmonger.UILogic.Converters
{
    public class NetValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((decimal)value > 0)
            {
                return new SolidColorBrush(Colors.Green);
            }

            return new SolidColorBrush(Colors.LightPink);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}