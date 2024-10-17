using System;

namespace InsuranceManagementSystem.entity
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public required string ClaimNumber { get; set; }
        public DateTime DateFiled { get; set; }
        public decimal ClaimAmount { get; set; }
        public required string Status { get; set; }
        public int PolicyId { get; set; }
        public int ClientId { get; set; }

        public Claim() { }

        public Claim(int claimId, string claimNumber, DateTime dateFiled, decimal claimAmount, string status, int policyId, int clientId)
        {
            ClaimId = claimId;
            ClaimNumber = claimNumber;
            DateFiled = dateFiled;
            ClaimAmount = claimAmount;
            Status = status;
            PolicyId = policyId;
            ClientId = clientId;
        }

        public override string ToString()
        {
            return $"ClaimId: {ClaimId}, ClaimNumber: {ClaimNumber}, Status: {Status}, PolicyId: {PolicyId}, ClientId: {ClientId}";
        }
    }
}