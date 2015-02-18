using System;
using System.Linq;
using System.Windows.Data;

namespace Bizmonger.UILogic.Converters
{
    public class RemoveLeadingZerosConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var myString = value as string;
            return myString.TrimStart("0".ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}