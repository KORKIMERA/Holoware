using System;
using System.Windows.Data;

namespace Bizmonger.UILogic.Converters
{
    public class DateToNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }

            var date = (DateTime)value;
            var dateMatchesParameter = date.ToShortDateString() == parameter as string;

            if (dateMatchesParameter)
            {
                return null;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}