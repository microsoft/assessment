namespace Assessment.Shared.ZeroTrust.Data
{
    public class ZeroTrustTechnicalScenario
    {
        public ZeroTrustTechnicalScenario()
        {
            Recommendations = new List<ZeroTrustRecommendation>();
        }

        public string Name { get; set; }

        public List<ZeroTrustRecommendation> Recommendations { get; set; }
    }
}