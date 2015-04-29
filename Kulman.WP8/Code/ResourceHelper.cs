using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using JetBrains.Annotations;

namespace Kulman.WP8.Code
{
    /// <summary>
    /// Helper class for accessing resources from code
    /// </summary>
    public static class ResourceHelper
    {       
        /// <summary>
        /// Gets a resource by name
        /// </summary>
        /// <typeparam name="T">Resource type</typeparam>
        /// <param name="name">Resource name</param>
        /// <returns>Resource</returns>
        [NotNull]
        public static T Get<T>([NotNull]string name)
        {
            return (T)Application.Current.Resources[name];
        }
    }
}
