using System.IO.IsolatedStorage;
using Kulman.WP8.Interfaces;

namespace Kulman.WP8.Services
{
    /// <summary>
    /// ISettingsService implementation usinng isolated storage settings
    /// </summary>
    public class StorageSettingsService: ISettingsService
    {
        private static readonly IsolatedStorageSettings AppSettings = IsolatedStorageSettings.ApplicationSettings;
        private static readonly object syncLock = new object();
        public static object SyncLock { get { return syncLock; } }

        /// <summary>
        /// Makes a string safe to be used as storage key
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>Safe strign for settings</returns>
        private static string SafeString(string s)
        {
            return s.Replace("\0", " ");
        }

        /// <summary>
        /// Gets a storred value for a given key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public object Get(string key)
        {
            lock (StorageSettingsService.SyncLock)
            {
                return AppSettings.Contains(SafeString(key)) ? AppSettings[SafeString(key)] : null;
            }
        }

        /// <summary>
        /// Save a key-value pair to settings
        /// Overwites existing
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void Set(string key, object value)
        {
            lock (StorageSettingsService.SyncLock)
            {
                if (AppSettings.Contains(SafeString(key)))
                {
                    AppSettings[SafeString(key)] = (value is string) ? SafeString((string)value) : value;
                    AppSettings.Save();
                    return;
                }

                AppSettings.Add(SafeString(key), (value is string) ? SafeString((string)value) : value);
                AppSettings.Save();
            }
        }

        /// <summary>
        /// Clears all settings
        /// </summary>
        public void ClearAll()
        {
            lock (StorageSettingsService.SyncLock)
            {
                AppSettings.Clear();
                AppSettings.Save();
            }
        }
    }
}
