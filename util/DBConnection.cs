using System;
using System.Data.SqlClient;

namespace InsuranceManagementSystem.util
{
    public class DBConnection
    {
        // Directly set the connection string here
        private static string connectionString = "Server=LAPTOP-E8Q2MF96\\SQLEXPRESS;Database=InsuranceManagementDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                Console.WriteLine("Database connection successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection error: " + ex.Message);
            }
            return conn;
        }
    }
}
