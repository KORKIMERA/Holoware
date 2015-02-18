using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace Bismonger.UILogic.Converters
{
    public class TruncateEnumerablesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var items = value as IEnumerable<string>;
            var delimeter = parameter as string;

            if (items == null)
            {
                return value;
            }

            var truncatedItems = items.Select(f => f.Split(delimeter[0]).Last());

            return truncatedItems;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}