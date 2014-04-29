using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Kulman.WP8.Converters.Abstract
{
    public abstract class BaseConverter<TFrom, TTo> : IValueConverter
    {
        public abstract TTo Convert(TFrom value);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null && !typeof(TFrom).IsValueType)
            {
                bool nullable;

                if (typeof(TFrom).IsValueType)
                {
                    nullable = Nullable.GetUnderlyingType(typeof(TFrom)) != null;
                }
                else
                {
                    nullable = true;
                }

                if (nullable)
                {
                    return Convert(default(TFrom));
                }
            }

            if (value is TFrom)
            {
                return Convert((TFrom)value);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
