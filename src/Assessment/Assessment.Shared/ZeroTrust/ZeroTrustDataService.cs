using Assessment.Shared.ZeroTrust.Data;
using Assessment.Shared.ZeroTrust.Recommendations;
using Microsoft.Graph;

namespace Assessment.Shared.ZeroTrust
{
    public class ZeroTrustDataService : IZeroTrustDataService
    {
        private readonly GraphServiceClient client;        

        public ZeroTrustDataService(GraphServiceClient client)
        {
            this.client = client;
        }

        private async Task GetTenantInfoAsync(ZeroTrustData zeroTrustData)
        {
            var tenant = await client.Organization.Request().GetAsync();
            var me = await client.Me.Request().GetAsync();

            if (tenant != null)
            {
                zeroTrustData.TenantName = tenant[0].DisplayName;
                zeroTrustData.AssessedBy = string.Format("{0} ({1})", me.DisplayName, me.Mail);
            }
            zeroTrustData.DateAssessed = DateTime.UtcNow;
        }

        public async Task<ZeroTrustData?> GetZeroTrustDataAsync()
        {
            ZeroTrustData zeroTrustData = InitializeMetadata();
            await GetTenantInfoAsync(zeroTrustData);
            foreach (var bs in zeroTrustData.BusinessScenarios)
            {
                foreach (var ts in bs.TechnicalScenarios)
                {
                    foreach (var r in ts.Recommendations)
                    {
                        if (!string.IsNullOrEmpty(r.ClassName))
                        {
                            IZeroTrustRecommendation? recommendation = Activator.CreateInstance(Type.GetType($"Assessment.Shared.ZeroTrust.Recommendations.{r.ClassName}")) as IZeroTrustRecommendation;
                            if (recommendation != null)
                            {
                                await recommendation.CheckRecommendationAsync(r, client);
                            }
                        }
                    }
                }
            }
            return zeroTrustData;
        }

        private ZeroTrustData InitializeMetadata()
        {
            ZeroTrustData zeroTrustData = new ZeroTrustData();

            var bs = new ZeroTrustBusinessScenario() { Name = "I want my people to do their job securely from anywhere." }; zeroTrustData.BusinessScenarios.Add(bs);
            var ts = new ZeroTrustTechnicalScenario() { Name = "I need to strengthen my credentials" }; bs.TechnicalScenarios.Add(ts);
            var r = new ZeroTrustRecommendation() { Name = "Multi-Factor Authentication (MFA) has been enabled and appropriate methods for MFA have been selected", ClassName = "" }; ts.Recommendations.Add(r);
            var c = new ZeroTrustCheck() { Id = "R0002C01-CombinedReg", Name = "Combined User Registration has been enabled for your directory, allows users to register for SSPR and MFA in one step", License = "P1", ProductName = "Azure Active Directory", ZeroTrustPrincipal = "Assume Breach" }; r.Checks.Add(c);
            c = new ZeroTrustCheck() { Id = "R0001C02-ConfigureMFA", Name = "Configure MFA and select appropriate methods for MFA", License = "Free", ProductName = "Azure Active Directory", ZeroTrustPrincipal = "" }; r.Checks.Add(c);


            bs = new ZeroTrustBusinessScenario() { Name = "I want to identify and protect my sensitive business data."}; zeroTrustData.BusinessScenarios.Add(bs);
            ts = new ZeroTrustTechnicalScenario() { Name = "How do I secure my M365 Apps and Data within those apps?" };bs.TechnicalScenarios.Add(ts);
            r = new ZeroTrustRecommendation() { Name = "Protect from data leakage on mobile devices at the application layer", ClassName = "R0001MobileDataLeakage" };ts.Recommendations.Add(r);
            c = new ZeroTrustCheck() { Id = "R0001C01-iOSAppProt", Name = "Enable Intune App Protection Policy for iOS", License = "", ProductName = "EndPoint Manager / Intune", ZeroTrustPrincipal = ""  }; r.Checks.Add(c);
            c = new ZeroTrustCheck() { Id = "R0001C02-AndroidAppProt", Name = "Enable Intune App Protection Policy for Android", License = "", ProductName = "EndPoint Manager / Intune", ZeroTrustPrincipal = "" }; r.Checks.Add(c);




            return zeroTrustData;
        }
    }
}
