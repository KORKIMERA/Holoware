using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Bizmonger.UILogic.Converters
{
    public class FileToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var image = value as Image;
            var filePath = image.DataContext as string;

            image.Source = new BitmapImage(new Uri(filePath));
            image.Height = image.Width = 100;

            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}