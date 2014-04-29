using System;
using System.Windows.Data;
using Kulman.WP8.Converters.Abstract;

namespace Kulman.WP8.Converters
{
    /// <summary>
    /// Converts give string to lower case
    /// </summary>
    public class LowerCaseConverter: BaseConverter<string,string>
    {
        public override string Convert(string value)
        {
            if (String.IsNullOrEmpty(value)) return null;

            return value.ToLower();
        }
    }
}
