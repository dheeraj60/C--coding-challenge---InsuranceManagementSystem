namespace InsuranceManagementSystem.entity
{
    public class Client
    {
        public int ClientId { get; set; }
        public required string ClientName { get; set; } 
        public required string ContactInfo { get; set; } 
        public int PolicyId { get; set; }

        public Client() { }

        public Client(int clientId, string clientName, string contactInfo, int policyId)
        {
            ClientId = clientId;
            ClientName = clientName;
            ContactInfo = contactInfo;
            PolicyId = policyId;
        }

        public override string ToString()
        {
            return $"ClientId: {ClientId}, ClientName: {ClientName}, ContactInfo: {ContactInfo}, PolicyId: {PolicyId}";
        }
    }
}