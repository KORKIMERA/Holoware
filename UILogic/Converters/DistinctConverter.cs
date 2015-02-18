using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace Bizmonger.UILogic.Converters
{
    public class DistinctConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var values = value as IEnumerable<string>;
            return values.Distinct();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
