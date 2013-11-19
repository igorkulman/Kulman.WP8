using System;
using Kulman.WP8.Interfaces;
using Microsoft.Phone.Info;

namespace Kulman.WP8.Services
{
    public class DeviceInformationService : IDeviceInformationService
    {
        /// <summary>
        /// Checks if power saving mode is currently enabled
        /// </summary>
        /// <returns>True if power saving mode is enabled, false otherwise</returns>
        public bool IsPowerSavingModeEnabled()
        {
            if (Environment.OSVersion.Version >= new Version(8, 0, 10492))
            {
               return (bool)typeof(Windows.Phone.System.Power.PowerManager).GetProperty("PowerSavingModeEnabled").GetValue(null, null);
            }

            return false;
        }

        /// <summary>
        /// Checks if the device has less than 512 MB RAM
        /// </summary>
        /// <returns>True if the device has less than 512 MB RAM, false otherwise</returns>
        public bool IsLowMemDevice()
        {
            try
            {
                var result = (Int64)DeviceExtendedProperties.GetValue("ApplicationWorkingSetLimit");
                return result < 94371840L;
            }
            catch (ArgumentOutOfRangeException)
            {
                // Windows Phone OS update not installed, which indicates a 512-MB device. 
                return false;
            }
        }

        /// <summary>
        /// Gets the device unique id
        /// Requirements: WMAppManifest.xml -> Capabilities tab -> switch on ID_CAP_IDENTITY_DEVICE
        /// </summary>
        /// <returns>Device unique id</returns>
        public string GetDeviceUniqueId()
        {
            return (string)DeviceExtendedProperties.GetValue("DeviceUniqueId");
        }
    }
}
