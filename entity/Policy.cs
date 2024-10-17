namespace InsuranceManagementSystem.entity
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public required string PolicyName { get; set; }
        public required string PolicyDetails { get; set; }

        public Policy() { }

        public Policy(int policyId, string policyName, string policyDetails)
        {
            PolicyId = policyId;
            PolicyName = policyName;
            PolicyDetails = policyDetails;
        }

        public override string ToString()
        {
            return $"PolicyId: {PolicyId}, PolicyName: {PolicyName}, PolicyDetails: {PolicyDetails}";
        }
    }
}