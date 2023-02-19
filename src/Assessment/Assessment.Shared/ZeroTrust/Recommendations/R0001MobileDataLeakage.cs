using Assessment.Shared.ZeroTrust.Data;
using Microsoft.Graph;

namespace Assessment.Shared.ZeroTrust.Recommendations
{
    internal class R0001MobileDataLeakage : IZeroTrustRecommendation
    {
        public async Task CheckRecommendationAsync(ZeroTrustRecommendation recommendation, GraphServiceClient client)
        {
            var request = client.DeviceAppManagement.ManagedAppPolicies.Request();
            var appProtectionPolicies = await request.GetAsync();

            bool hasIosPolicy = false;
            bool hasAndroidPolicy = false;

            if (appProtectionPolicies != null)
            {
                hasIosPolicy = appProtectionPolicies.Any(p => p.ODataType == "#microsoft.graph.iosManagedAppProtection");
                hasAndroidPolicy = appProtectionPolicies.Any(p => p.ODataType == "#microsoft.graph.androidManagedAppProtection");
            }
            foreach(var check in recommendation.Checks)
            {
                switch(check.Id)
                {
                    case "R0001C01-iOSAppProt":
                        check.Status = hasIosPolicy ? CheckStatus.Success : CheckStatus.Fail; break;
                    case "R0001C02-AndroidAppProt":
                        check.Status = hasAndroidPolicy ? CheckStatus.Success : CheckStatus.Fail; break;
                }
            }
        }
    }
}