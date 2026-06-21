using System;
using System.IO;

namespace SSMS
{
    internal class EnvironmentConfig
    {
        private static bool _isLoaded = false;

        /// <summary>
        /// Load environment variables from .env file
        /// </summary>
        public static void Load()
        {
            if (_isLoaded) return;

            try
            {
                // Get the path to the .env file
                string envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");

                // If not found in base directory, check current directory (for development)
                if (!File.Exists(envPath))
                {
                    envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
                }

                // If still not found, check two directories up (common for development)
                if (!File.Exists(envPath))
                {
                    string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    envPath = Path.Combine(projectDir, ".env");
                }

                if (File.Exists(envPath))
                {
                    LoadEnvFile(envPath);
                    _isLoaded = true;
                }
                else
                {
                    // Don't throw exception, just use defaults
                    Console.WriteLine($".env file not found at: {envPath}. Using default values.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load .env file: {ex.Message}. Using default values.");
            }
        }

        /// <summary>
        /// Parse .env file and set environment variables
        /// </summary>
        private static void LoadEnvFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                // Skip empty lines and comments
                if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("#"))
                    continue;

                // Find the equals sign
                int equalsIndex = line.IndexOf('=');
                if (equalsIndex > 0)
                {
                    string key = line.Substring(0, equalsIndex).Trim();
                    string value = line.Substring(equalsIndex + 1).Trim();

                    // Remove quotes if present
                    if (value.StartsWith("\"") && value.EndsWith("\""))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }
                    else if (value.StartsWith("'") && value.EndsWith("'"))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }

                    // Set environment variable
                    Environment.SetEnvironmentVariable(key, value);
                }
            }
        }

        /// <summary>
        /// Get MySQL connection string from environment variables
        /// </summary>
        public static string GetConnectionString()
        {
            Load(); // Ensure .env is loaded

            string host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DB_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DB_NAME") ?? "ssmsdb";
            string user = Environment.GetEnvironmentVariable("DB_USER") ?? "root";
            string password = Environment.GetEnvironmentVariable("DB_PASS") ?? "";

            return $"Server={host};Port={port};Database={database};Uid={user};Pwd={password};";
        }

        /// <summary>
        /// Get a specific environment variable
        /// </summary>
        public static string GetVariable(string key)
        {
            Load(); // Ensure .env is loaded
            return Environment.GetEnvironmentVariable(key);
        }

        /// <summary>
        /// Check if running in development mode
        /// </summary>
        public static bool IsDevelopment()
        {
            string env = GetVariable("APP_ENV");
            return string.IsNullOrEmpty(env) || env.ToLower() == "development";
        }

        /// <summary>
        /// Check if running in production mode
        /// </summary>
        public static bool IsProduction()
        {
            return GetVariable("APP_ENV")?.ToLower() == "production";
        }
    }
}