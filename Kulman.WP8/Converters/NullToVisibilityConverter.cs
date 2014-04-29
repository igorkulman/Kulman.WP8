using System;
using System.Windows;
using System.Windows.Data;
using Kulman.WP8.Converters.Abstract;

namespace Kulman.WP8.Converters
{
    /// <summary>
    /// Converts null to Visibility.Collapsed
    /// Can be inverted
    /// </summary>
    public class NullToVisibilityConverter : BaseVisibilityConverter<object>
    {
        public bool IsInverted { get; set; }

        protected override bool? ConvertToVisibility(object value)
        {
            return IsInverted ? value == null : value != null;
        }
    }
}
