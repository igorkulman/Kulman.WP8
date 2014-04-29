using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Kulman.WP8.Converters.Abstract;

namespace Kulman.WP8.Converters
{
    /// <summary>
    /// Converts true to Visibility.Collapsed
    /// Can be inverted
    /// </summary>
    public class BooleanToVisibilityConverter : BaseVisibilityConverter<bool>
    {
        public bool IsInverted { get; set; }

        protected override bool? ConvertToVisibility(bool value)
        {
            return IsInverted ? !value : value;
        }
    }
}
