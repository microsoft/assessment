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
        public ZeroTrustCheck()
        {
            Status = CheckStatus.NotChecked;
        }
        public CheckStatus Status { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string License { get; set; }
        public string ProductName { get; set; }
        public string ZeroTrustPrincipal { get; set; }
    }
}
