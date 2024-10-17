using InsuranceManagementSystem.entity;
using InsuranceManagementSystem.exception;
using System;
using System.Collections.Generic;

namespace InsuranceManagementSystem.dao
{
    public class InsuranceServiceImpl : IPolicyService
    {
        private PolicyServiceImpl policyService = new PolicyServiceImpl();

        public bool CreatePolicy(Policy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy), "Policy cannot be null.");
            }

            return policyService.CreatePolicy(policy);
        }

        
        public Policy GetPolicy(int policyId)
        {
            if (policyId <= 0)
            {
                throw new ArgumentException("Policy ID must be greater than zero.", nameof(policyId));
            }

            var policy = policyService.GetPolicy(policyId);
            if (policy == null) 
            {
                throw new PolicyNotFoundException($"Policy with ID {policyId} not found.");
            }

            return policy;
        }

        // Method to retrieve all policies
        public List<Policy> GetAllPolicies()
        {
            return policyService.GetAllPolicies();
        }

        // Method to update a policy
        public bool UpdatePolicy(Policy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy), "Policy cannot be null.");
            }

            return policyService.UpdatePolicy(policy);
        }

        // Method to delete a policy
        public bool DeletePolicy(int policyId)
        {
            if (policyId <= 0)
            {
                throw new ArgumentException("Policy ID must be greater than zero.", nameof(policyId));
            }

            return policyService.DeletePolicy(policyId);
        }
    }
}
