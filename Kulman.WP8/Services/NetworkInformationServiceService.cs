using System.Linq;
using System.Net;
using Kulman.WP8.Interfaces;
using Microsoft.Phone.Net.NetworkInformation;
using Windows.Networking.Connectivity;

namespace Kulman.WP8.Services
{
    /// <summary>
    /// Network information service
    /// </summary>
    public class NetworkInformationServiceService: INetworkInformationService
    {
        /// <summary>
        /// Checks if network connectivity is available
        /// </summary>
        /// <returns>True if network connectivity available, false otherwise</returns>
        public bool IsNetworkAvailable()
        {
            return DeviceNetworkInformation.IsNetworkAvailable;
        }

        /// <summary>
        /// Checks if the device is connected to WiFi network
        /// </summary>
        /// <returns>True if WiFi available, false otherwise</returns>
        public bool IsOnWiFi()
        {
            return DeviceNetworkInformation.IsWiFiEnabled;
        }

        /// <summary>
        /// Checks if the device has Internet connection
        /// </summary>
        /// <returns>True if the device has Internet connection, false otherwise</returns>
        public bool IsInternetAvailable()
        {            
            return DeviceNetworkInformation.IsWiFiEnabled || DeviceNetworkInformation.IsCellularDataEnabled;
        }

        /// <summary>
        /// Gets the current IP address
        /// </summary>
        /// <returns>Current IP address</returns>
        public IPAddress GetCurrentIPAddress()
        {
            var hostnames = NetworkInformation.GetHostNames();
            var ipAddresses = (from hn in hostnames where hn.IPInformation != null select hn.DisplayName).ToList();

            var address = IPAddress.Parse(ipAddresses[0]);
            return address;
        }
    }
}
