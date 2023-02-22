namespace Assessment.Shared.ZeroTrust.Data
{
    public enum CheckStatus
    {
        Success,
        Fail,
        NotChecked
    }
    public class ZeroTrustCheck
    {
        public ZeroTrustCheck(ZeroTrustRecommendation recommendation, ZeroTrustTechnicalScenario technicalScenario, ZeroTrustBusinessScenario businessScenario)
        {
            Status = CheckStatus.NotChecked;
            Recommendation = recommendation;
            TechnicalScenario = technicalScenario;
            BusinessScenario = businessScenario;
        }

        public CheckStatus Status { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string License { get; set; }
        public string ProductName { get; set; }
        public string ZeroTrustPrincipal { get; set; }

        public ZeroTrustRecommendation Recommendation { get; private set; }
        public ZeroTrustTechnicalScenario TechnicalScenario { get; private set; }
        public ZeroTrustBusinessScenario BusinessScenario { get; private set; }
        public string DocLinkText { get; internal set; }
        public string DocLinkUrl { get; internal set; }
    }
}
