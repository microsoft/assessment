using Assessment.Shared.ZeroTrust.Data;

namespace Assessment.Shared.ZeroTrust
{
    public interface IZeroTrustDataService
    {
        Task<ZeroTrustData?> GetZeroTrustDataAsync();
    }
}