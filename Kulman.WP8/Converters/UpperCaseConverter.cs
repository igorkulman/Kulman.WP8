using System;
using System.Windows.Data;

namespace Kulman.WP8.Converters
{
    /// <summary>
    /// Converts give string to upper case
    /// </summary>
    public class UpperCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            var s = (string)value;

            return s.ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
