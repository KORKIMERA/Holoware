using System;
using System.Windows.Data;

namespace Bismonger.UILogic.Converters
{
    public class DateTimeNowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter == null)
            {
                return DateTime.Now;
            }

            else
            {
                var daysOffset = int.Parse(parameter as string);
                return DateTime.Now.AddDays(daysOffset);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}