using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Kulman.WP8.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public bool IsReversed { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isVisible = (bool)value;

            if (IsReversed)
            {
                return isVisible ? Visibility.Collapsed : Visibility.Visible;
            }
            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
