namespace Inmite.Core.Win8.Services
{
    public enum PurchaseResult
    {
        Ok,
        Cancel,
        Error
    }

    /// <summary>
    /// Result from Windows Store service
    /// </summary>
    public class PurchaseResponse
    {
        public PurchaseResult Result { get; set; }
        public string Receipt { get; set; }
    }
}
