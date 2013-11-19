using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.ApplicationModel.Store;
using Windows.Storage;

namespace Inmite.Core.Win8.Services
{
    /// <summary>
    /// Windows Store service
    /// </summary>
    public class WindowsStoreService:IWindowsStoreService
    {
#if DEBUG
        private const string TestReceipt = "<Receipt Version=\"1.0\" ReceiptDate=\"2012-08-30T23:08:52Z\" CertificateId=\"b809e47cd0110a4db043b3f73e83acd917fe1336\" ReceiptDeviceId=\"4e362949-acc3-fe3a-e71b-89893eb4f528\">	<ProductReceipt Id=\"6bbf4366-6fb2-8be8-7947-92fd5f683530\" ProductId=\"Product1\" PurchaseDate=\"2012-08-30T23:08:52Z\" ExpirationDate=\"2012-09-02T23:08:49Z\" ProductType=\"Durable\" AppId=\"55428GreenlakeApps.CurrentAppSimulatorEventTest_z7q3q7z11crfr\" />	<Signature xmlns=\"http://www.w3.org/2000/09/xmldsig#\">		<SignedInfo>			<CanonicalizationMethod Algorithm=\"http://www.w3.org/2001/10/xml-exc-c14n#\" />			<SignatureMethod Algorithm=\"http://www.w3.org/2001/04/xmldsig-more#rsa-sha256\" />			<Reference URI=\"\">				<Transforms>					<Transform Algorithm=\"http://www.w3.org/2000/09/xmldsig#enveloped-signature\" />				</Transforms>				<DigestMethod Algorithm=\"http://www.w3.org/2001/04/xmlenc#sha256\" />				<DigestValue>Uvi8jkTYd3HtpMmAMpOm94fLeqmcQ2KCrV1XmSuY1xI=</DigestValue>			</Reference>		</SignedInfo>		<SignatureValue>TT5fDET1X9nBk9/yKEJAjVASKjall3gw8u9N5Uizx4/Le9RtJtv+E9XSMjrOXK/TDicidIPLBjTbcZylYZdGPkMvAIc3/1mdLMZYJc+EXG9IsE9L74LmJ0OqGH5WjGK/UexAXxVBWDtBbDI2JLOaBevYsyy+4hLOcTXDSUA4tXwPa2Bi+BRoUTdYE2mFW7ytOJNEs3jTiHrCK6JRvTyU9lGkNDMNx9loIr+mRks+BSf70KxPtE9XCpCvXyWa/Q1JaIyZI7llCH45Dn4SKFn6L/JBw8G8xSTrZ3sBYBKOnUDbSCfc8ucQX97EyivSPURvTyImmjpsXDm2LBaEgAMADg==</SignatureValue>	</Signature></Receipt>";
#endif

        /// <summary>
        /// Checks if a product is purchased
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>True if the product is purchased</returns>
        public bool IsPurchased(string productId)
        {
            if (String.IsNullOrEmpty(productId)) return false;

            #if DEBUG
                        var licenseInformation = CurrentAppSimulator.LicenseInformation;
            #else
                        var licenseInformation = CurrentApp.LicenseInformation;    
            #endif

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
#if DEBUG
                var products = await CurrentAppSimulator.LoadListingInformationAsync();
#else
                var products = await CurrentApp.LoadListingInformationAsync();
#endif
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
        /// Gets the receipt for give product. If the receipt is not available, gets the receipt id
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>Receipt or receipt id</returns>
        public async Task<string> GetReceiptOrReceiptId(string productId)
        {           
#if DEBUG
            return TestReceipt;
#endif


#if DEBUG
            var licenseInformation = CurrentAppSimulator.LicenseInformation;
#else
                        var licenseInformation = CurrentApp.LicenseInformation;    
#endif

            if (!licenseInformation.ProductLicenses[productId].IsActive)
            {
                return null;
            }

            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(productId))
            {
                return ApplicationData.Current.LocalSettings.Values[productId].ToString();
            }

#if DEBUG
            var appReceipt = await CurrentAppSimulator.GetAppReceiptAsync();
#else
            var appReceipt = await CurrentApp.GetAppReceiptAsync(); 
#endif
            try
            {
                var doc = XDocument.Parse(appReceipt);
                var receiptInfo = doc.Descendants("ProductReceipt")
                                     .SingleOrDefault(l => l.Attribute("ProductId").Value == productId);
                if (receiptInfo != null)
                {
                    return receiptInfo.Attribute("Id").Value;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return null;
        }

        /// <summary>
        /// Tries to buy a product and get back the receipt
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>Response containing the buy result and receipt (if available)</returns>
        public async Task<PurchaseResponse> BuyAndGetReceipt(string productId)
        {
            if (String.IsNullOrEmpty(productId))
            {
                return new PurchaseResponse
                    {
                        Result = PurchaseResult.Error
                    };
            }


            try
            {

#if DEBUG
                var receipt = await CurrentAppSimulator.RequestProductPurchaseAsync(productId, true);
                receipt = TestReceipt;
                    

#else
            var receipt = await CurrentApp.RequestProductPurchaseAsync(productId, true);
#endif

#if DEBUG
                var licenseInformation = CurrentAppSimulator.LicenseInformation;
#else
            var licenseInformation = CurrentApp.LicenseInformation;    
#endif


#if DEBUG
                if (true)
#else
                if (licenseInformation.ProductLicenses[productId].IsActive)
#endif
                {
                    ApplicationData.Current.LocalSettings.Values[productId] = receipt;

                    return new PurchaseResponse
                    {
                        Result = PurchaseResult.Ok,
                        Receipt = receipt
                    };
                }
                else
                {
                    return new PurchaseResponse
                    {
                        Result = PurchaseResult.Cancel
                    };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new PurchaseResponse
                    {
                        Result = PurchaseResult.Error
                    };
            }
        }
    }
}
