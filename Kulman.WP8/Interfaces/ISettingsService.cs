namespace Kulman.WP8.Interfaces
{
    /// <summary>
    /// Interface definition for settings manipulation
    /// </summary>
    public interface ISettingsService
    {
        /// <summary>
        /// Gets a storred value for a given key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        object Get(string key);

        /// <summary>
        /// Save a key-value pair to settings
        /// Overwites existing
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        void Set(string key, object value);
    }
}
