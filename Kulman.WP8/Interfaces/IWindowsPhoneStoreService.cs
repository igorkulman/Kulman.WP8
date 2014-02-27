using System.Threading.Tasks;
using Kulman.WP8.Code;

namespace Kulman.WP8.Interfaces
{
    /// <summary>
    /// Interface for Windows Phone Store service
    /// </summary>
    public interface IWindowsPhoneStoreService
    {
        /// <summary>
        /// Checks if a product is purchased
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>True if the product is purchased</returns>
        bool IsPurchased(string productId);

        /// <summary>
        /// Tries to purchase a product
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>True on success, false otherwise</returns>
        Task<bool> Purchase(string productId);

        /// <summary>
        /// Gets the price of a product
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>Product price</returns>
        Task<string> GetPrice(string productId);        
    }
}
