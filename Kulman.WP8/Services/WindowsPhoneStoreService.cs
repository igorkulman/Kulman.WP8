using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Kulman.WP8.Code;
using Kulman.WP8.Interfaces;

namespace Kulman.WP8.Services
{
    /// <summary>
    /// Windows Phone Store service
    /// </summary>
    public class WindowsPhoneStoreService : IWindowsPhoneStoreService
    {

        /// <summary>
        /// Checks if a product is purchased
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>True if the product is purchased</returns>
        public bool IsPurchased(string productId)
        {
            if (String.IsNullOrEmpty(productId)) return false;

            var licenseInformation = CurrentApp.LicenseInformation;
            return licenseInformation.ProductLicenses[productId].IsActive;
        }

        /// <summary>
        /// Gets the price of a product
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>Product price</returns>
        public async Task<string> GetPrice(string productId)
        {
            try
            {
                var products = await CurrentApp.LoadListingInformationAsync();

                var product = products.ProductListings.SingleOrDefault(l => l.Value.ProductId == productId);
                if (product.Value == null) return string.Empty;

                return product.Value.FormattedPrice;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Tries to purchase a product
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>True on success, false otherwise</returns>
        public async Task<bool> Purchase(string productId)
        {
            if (String.IsNullOrEmpty(productId))
            {
                return false;
            }


            try
            {
                await CurrentApp.RequestProductPurchaseAsync(productId, false);

                try
                {
                    var licenses = CurrentApp.LicenseInformation.ProductLicenses;
                    if (licenses["productId"].IsConsumable && licenses["productId"].IsActive)
                    {
                        CurrentApp.ReportProductFulfillment(productId);
                    }
                }
                catch (Exception e)
                {
                    
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
