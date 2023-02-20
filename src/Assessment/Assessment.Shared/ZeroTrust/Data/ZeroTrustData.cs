namespace Assessment.Shared.ZeroTrust.Data
{
    public class ZeroTrustData
    {
        public ZeroTrustData()
        {
            BusinessScenarios = new List<ZeroTrustBusinessScenario>();
            Checks = new List<ZeroTrustCheck>();
        }
        public string TenantName { get; set; }
        public DateTime DateAssessed { get; set; }
        public string AssessedBy { get; set; }

        public List<ZeroTrustBusinessScenario> BusinessScenarios { get; set; }

        public List<ZeroTrustCheck> Checks { get; set; }
    }
}