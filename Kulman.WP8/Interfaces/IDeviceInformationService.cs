namespace Kulman.WP8.Interfaces
{
    public interface IDeviceInformationService
    {
        /// <summary>
        /// Checks if power saving mode is currently enabled
        /// </summary>
        /// <returns>True if power saving mode is enabled, false otherwise</returns>
        bool IsPowerSavingModeEnabled();

        /// <summary>
        /// Checks if the device has less than 512 MB RAM
        /// </summary>
        /// <returns>True if the device has less than 512 MB RAM, false otherwise</returns>
        bool IsLowMemDevice();

        /// <summary>
        /// Gets the device unique id
        /// Requirements: WMAppManifest.xml -> Capabilities tab -> switch on ID_CAP_IDENTITY_DEVICE
        /// </summary>
        /// <returns>Device unique id</returns>
        string GetDeviceUniqueId();

        /// <summary>
        /// Gets the free space available for the application
        /// </summary>
        /// <returns>Free space available</returns>
        long GetAvailableFreeSpace();
    }
}
