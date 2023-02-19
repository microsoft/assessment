namespace Assessment.Shared.ZeroTrust.Data
{
    public class ZeroTrustRecommendation
    {
        public ZeroTrustRecommendation()
        {
            Checks = new List<ZeroTrustCheck>();
        }
        public string Id { get; set; }
        public string ClassName { get; set; }
        public string Name { get; set; }
        public List<ZeroTrustCheck> Checks { get; set; }
    }
}
