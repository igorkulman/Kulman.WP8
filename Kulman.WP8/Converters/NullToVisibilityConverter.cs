using System;
using System.Windows;
using System.Windows.Data;

namespace Kulman.WP8.Converters
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public bool IsReversed { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (IsReversed)
            {
                return value == null ? Visibility.Visible : Visibility.Collapsed;
            }
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
