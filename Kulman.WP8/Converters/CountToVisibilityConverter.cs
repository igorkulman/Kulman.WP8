using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulman.WP8.Converters.Abstract;

namespace Kulman.WP8.Converters
{
    public class CountToVisibilityConverter: BaseVisibilityConverter<int>
    {
        public bool IsInverted { get; set; }

        protected override bool? ConvertToVisibility(int value)
        {
            return (IsInverted) ? value==0 : value > 0;
        }
    }
}
