namespace Kulman.WP8.Interfaces
{
    public interface INetworkInformation
    {
        bool IsNetworkAvailable();
        bool IsOnWiFi();
        bool IsInternetAvailable();
    }
}
