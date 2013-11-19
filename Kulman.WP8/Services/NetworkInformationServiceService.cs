using Kulman.WP8.Interfaces;
using Microsoft.Phone.Net.NetworkInformation;

namespace Kulman.WP8.Services
{
    public class NetworkInformationServiceService: INetworkInformationService
    {
        public bool IsNetworkAvailable()
        {
            return DeviceNetworkInformation.IsNetworkAvailable;
        }

        public bool IsOnWiFi()
        {
            return DeviceNetworkInformation.IsWiFiEnabled;
        }

        public bool IsInternetAvailable()
        {            
            return DeviceNetworkInformation.IsWiFiEnabled || DeviceNetworkInformation.IsCellularDataEnabled;
        }
    }
}
