using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulman.WP8.Converters.Abstract;

namespace Kulman.WP8.Converters
{
    public class ObjectToVisibilityConverter : BaseVisibilityConverter<object>
    {
        protected override bool? ConvertToVisibility(object value)
        {
            if (value is string)
            {
                return !String.IsNullOrWhiteSpace((string)value);
            }

            if (value is IEnumerable)
            {
                return ((IEnumerable)value).Cast<object>().Any();
            }

            return value != null;
        }
    }
}
