using System;
using System.IO;

namespace SSMS
{
    internal class EnvironmentConfig
    {
        private static bool _isLoaded = false;

      
        public static void Load()
        {
            if (_isLoaded) return;

            try
            {
                
                string envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");

                
                if (!File.Exists(envPath))
                {
                    envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
                }

                
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
                    
                    Console.WriteLine($".env file not found at: {envPath}. Using default values.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load .env file: {ex.Message}. Using default values.");
            }
        }

     
        private static void LoadEnvFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                
                if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("#"))
                    continue;

                
                int equalsIndex = line.IndexOf('=');
                if (equalsIndex > 0)
                {
                    string key = line.Substring(0, equalsIndex).Trim();
                    string value = line.Substring(equalsIndex + 1).Trim();

                    
                    if (value.StartsWith("\"") && value.EndsWith("\""))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }
                    else if (value.StartsWith("'") && value.EndsWith("'"))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }

                    
                    Environment.SetEnvironmentVariable(key, value);
                }
            }
        }

       
        public static string GetConnectionString()
        {
            Load(); 

            string host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DB_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DB_NAME") ?? "ssmsdb";
            string user = Environment.GetEnvironmentVariable("DB_USER") ?? "root";
            string password = Environment.GetEnvironmentVariable("DB_PASS") ?? "";

            return $"Server={host};Port={port};Database={database};Uid={user};Pwd={password};";
        }

        public static string GetSmtpServer() { Load(); return Environment.GetEnvironmentVariable("SMTP_SERVER") ?? "smtp.gmail.com"; }
        public static int GetSmtpPort() { Load(); return int.TryParse(Environment.GetEnvironmentVariable("SMTP_PORT"), out int port) ? port : 587; }
        public static string GetSmtpUser() { Load(); return Environment.GetEnvironmentVariable("SMTP_USER") ?? ""; }
        public static string GetSmtpPass() { Load(); return Environment.GetEnvironmentVariable("SMTP_PASS") ?? ""; }
        
        public static string GetGroqApiKey() { Load(); return Environment.GetEnvironmentVariable("GROQ_API_KEY") ?? ""; }

      
        public static string GetVariable(string key)
        {
            Load(); 
            return Environment.GetEnvironmentVariable(key);
        }

       
        public static bool IsDevelopment()
        {
            string env = GetVariable("APP_ENV");
            return string.IsNullOrEmpty(env) || env.ToLower() == "development";
        }

        
        public static bool IsProduction()
        {
            return GetVariable("APP_ENV")?.ToLower() == "production";
        }
    }
}