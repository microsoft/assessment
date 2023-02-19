namespace Assessment.Shared.ZeroTrust.Data
{
    public class ZeroTrustBusinessScenario
    {
        public ZeroTrustBusinessScenario()
        {
            TechnicalScenarios = new List<ZeroTrustTechnicalScenario>();
        }
        public string Name { get; set; }
        public List<ZeroTrustTechnicalScenario> TechnicalScenarios { get; set; }
    }
}
