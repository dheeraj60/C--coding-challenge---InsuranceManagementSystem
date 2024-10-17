using System.Data.SqlClient;
using InsuranceManagementSystem.entity;
using InsuranceManagementSystem.exception;
using InsuranceManagementSystem.util;



namespace InsuranceManagementSystem.dao
{
    public class PolicyServiceImpl
    {
        public Policy GetPolicy(int policyId)
        {
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    string query = "SELECT * FROM Policies WHERE PolicyId = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", policyId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string policyName = reader["PolicyName"] as string ?? throw new InvalidOperationException("PolicyName cannot be null.");
                        string policyDetails = reader["PolicyDetails"] as string ?? throw new InvalidOperationException("PolicyDetails cannot be null.");

                        return new Policy
                        {
                            PolicyId = (int)reader["PolicyId"],
                            PolicyName = policyName,
                            PolicyDetails = policyDetails
                        };
                    }
                    else
                    {
                        throw new PolicyNotFoundException("Policy not found with ID: " + policyId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw; 
            }
        }

        public List<Policy> GetAllPolicies()
        {
            List<Policy> policies = new List<Policy>();
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    string query = "SELECT * FROM Policies";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string policyName = reader["PolicyName"] as string ?? throw new InvalidOperationException("PolicyName cannot be null.");
                        string policyDetails = reader["PolicyDetails"] as string ?? throw new InvalidOperationException("PolicyDetails cannot be null.");

                        policies.Add(new Policy
                        {
                            PolicyId = (int)reader["PolicyId"],
                            PolicyName = policyName,
                            PolicyDetails = policyDetails
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return policies;
        }

        // Method to create a new policy
        public bool CreatePolicy(Policy policy)
        {
            if (policy == null || string.IsNullOrEmpty(policy.PolicyName) || string.IsNullOrEmpty(policy.PolicyDetails))
            {
                throw new ArgumentException("PolicyName and PolicyDetails must be provided.");
            }

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    string query = "INSERT INTO Policies (PolicyName, PolicyDetails) VALUES (@name, @details)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", policy.PolicyName);
                    cmd.Parameters.AddWithValue("@details", policy.PolicyDetails);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        // Method to update an existing policy
        public bool UpdatePolicy(Policy policy)
        {
            if (policy == null || string.IsNullOrEmpty(policy.PolicyName) || string.IsNullOrEmpty(policy.PolicyDetails))
            {
                throw new ArgumentException("PolicyName and PolicyDetails must be provided.");
            }

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    string query = "UPDATE Policies SET PolicyName = @name, PolicyDetails = @details WHERE PolicyId = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", policy.PolicyName);
                    cmd.Parameters.AddWithValue("@details", policy.PolicyDetails);
                    cmd.Parameters.AddWithValue("@id", policy.PolicyId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        // Method to delete a policy by ID
        public bool DeletePolicy(int policyId)
        {
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    string query = "DELETE FROM Policies WHERE PolicyId = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", policyId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}