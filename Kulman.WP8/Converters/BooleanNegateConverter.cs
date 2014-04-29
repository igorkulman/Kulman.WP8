using System;
using System.Windows.Data;
using Kulman.WP8.Converters.Abstract;

namespace Kulman.WP8.Converters
{
    /// <summary>
    /// Negates a boolean value
    /// </summary>
    public class BooleanNegateConverter : BaseConverter<bool?,bool?>
    {
        public override bool? Convert(bool? value)
        {
            if (value == null) return true;
            return !value.Value;
        }
    }
}
