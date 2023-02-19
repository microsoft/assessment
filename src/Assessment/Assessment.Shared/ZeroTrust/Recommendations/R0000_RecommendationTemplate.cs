using Assessment.Shared.ZeroTrust.Data;
using Microsoft.Graph;

namespace Assessment.Shared.ZeroTrust.Recommendations
{
    internal class R0000_RecommendationTemplate : IZeroTrustRecommendation
    {
        public async Task CheckRecommendationAsync(ZeroTrustRecommendation recommendation, GraphServiceClient client)
        {
            foreach (var check in recommendation.Checks)
            {
                switch (check.Id)
                {
                    default:
                        check.Status = CheckStatus.NotChecked; break;
                }
            }
        }
    }
}