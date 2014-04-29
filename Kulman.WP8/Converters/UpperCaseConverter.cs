using System;
using System.Windows.Data;
using Kulman.WP8.Converters.Abstract;

namespace Kulman.WP8.Converters
{
    /// <summary>
    /// Converts give string to upper case
    /// </summary>
    public class UpperCaseConverter : BaseConverter<string, string>
    {
        public override string Convert(string value)
        {
            if (String.IsNullOrEmpty(value)) return null;

            return value.ToUpper();
        }
    }
}
