using System.Net;

namespace Kulman.WP8.Interfaces
{
    /// <summary>
    /// Interface definition for network information service
    /// </summary>
    public interface INetworkInformationService
    {
        /// <summary>
        /// Checks if network connectivity is available
        /// </summary>
        /// <returns>True if network connectivity available, false otherwise</returns>       
        bool IsNetworkAvailable();

        /// <summary>
        /// Checks if the device is connected to WiFi network
        /// </summary>
        /// <returns>True if WiFi available, false otherwise</returns>
        bool IsOnWiFi();

        /// <summary>
        /// Checks if the device has Internet connection
        /// </summary>
        /// <returns>True if the device has Internet connection, false otherwise</returns>
        bool IsInternetAvailable();

        /// <summary>
        /// Gets the current IP address
        /// </summary>
        /// <returns>Current IP address</returns>
        IPAddress GetCurrentIPAddress();
    }
}
