using System.Windows;

namespace Kulman.WP8.Converters.Abstract
{
    public abstract class BaseVisibilityConverter<TFrom> : BaseConverter<TFrom, Visibility>
    {
        protected abstract bool ConvertToVisibility(TFrom value);

        public sealed override Visibility Convert(TFrom value)
        {
            return ConvertToVisibility(value) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
