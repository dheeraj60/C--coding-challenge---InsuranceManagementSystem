using System;
using InsuranceManagementSystem.dao;
using InsuranceManagementSystem.entity;
using InsuranceManagementSystem.exception;

namespace InsuranceManagementSystem.mainmod
{
    class MainModule
    {
        static void Main(string[] args)
        {
            InsuranceServiceImpl insuranceService = new InsuranceServiceImpl();

            // Example policy for demonstration
            Policy newPolicy = new Policy
            {
                PolicyId = 1,
                PolicyName = "Health Insurance",
                PolicyDetails = "Covers hospitalization and surgery"
            };

            try
            {
                // Create a policy
                insuranceService.CreatePolicy(newPolicy);
                Console.WriteLine("Policy created successfully.");

                // Get a policy by ID
                Policy fetchedPolicy = insuranceService.GetPolicy(newPolicy.PolicyId);
                Console.WriteLine($"Fetched Policy: {fetchedPolicy.PolicyName}, Details: {fetchedPolicy.PolicyDetails}");

                // Update a policy
                fetchedPolicy.PolicyDetails = "Updated coverage details";
                insuranceService.UpdatePolicy(fetchedPolicy);
                Console.WriteLine("Policy updated successfully.");

                // Retrieve all policies
                var allPolicies = insuranceService.GetAllPolicies();
                Console.WriteLine($"Total Policies: {allPolicies.Count}");
                foreach (var policy in allPolicies)
                {
                    Console.WriteLine(policy.ToString());
                }

                // Delete a policy
                insuranceService.DeletePolicy(newPolicy.PolicyId);
                Console.WriteLine("Policy deleted successfully.");
            }
            catch (PolicyNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}