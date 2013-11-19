namespace Kulman.WP8.Interfaces
{
    public interface INetworkInformationService
    {
        bool IsNetworkAvailable();
        bool IsOnWiFi();
        bool IsInternetAvailable();
    }
}
