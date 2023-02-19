using Assessment.Shared.ZeroTrust.Data;
using Microsoft.Graph;

namespace Assessment.Shared.ZeroTrust.Recommendations
{
    internal interface IZeroTrustRecommendation
    {
        Task CheckRecommendationAsync(ZeroTrustRecommendation recommendation, GraphServiceClient client);
    }
}
