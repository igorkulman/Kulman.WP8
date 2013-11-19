using System;
using System.Windows;
using System.Windows.Data;

namespace Kulman.WP8.Converters
{
    /// <summary>
    /// Converts null to Visibility.Collapsed
    /// Can be inverted
    /// </summary>
    public class NullToVisibilityConverter : IValueConverter
    {
        public bool IsInverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (IsInverted)
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
