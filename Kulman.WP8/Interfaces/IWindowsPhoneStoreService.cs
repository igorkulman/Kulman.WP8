using System.Threading.Tasks;
using Kulman.WP8.Code;

namespace Kulman.WP8.Interfaces
{
    /// <summary>
    /// Interface for Windows Phone Store service
    /// </summary>
    public interface IWindowsPhoneStoreService
    {
        bool IsPurchased(string productId);
        Task<PurchaseResponse> Purchase(string productId);
        Task<string> GetPrice(string productId);        
    }
}
