using System;
using System.IO;
using System.Collections.Generic;

namespace InsuranceManagementSystem.util
{
    public static class PropertyUtil
    {
        private static Dictionary<string, string> properties;

        static PropertyUtil()
        {
            properties = new Dictionary<string, string>();
            LoadProperties("util/db.properties");
        }

        private static void LoadProperties(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                    {
                        var parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            properties[parts[0].Trim()] = parts[1].Trim();
                        }
                    }
                }
            }
            else
            {
                throw new FileNotFoundException($"Properties file not found: {filePath}");
            }
        }

        public static string GetConnectionString()
        {
            string hostname = properties["hostname"];
            string dbname = properties["dbname"];
            string port = properties.ContainsKey("port") ? properties["port"] : "1433";

            return $"Server={hostname};Database={dbname};Trusted_Connection=True;";
        }
    }
}
