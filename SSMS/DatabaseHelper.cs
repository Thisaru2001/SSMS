using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SSMS
{
    internal class DatabaseHelper
    {
        // Use EnvironmentConfig instead of hardcoded connection string
        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        // Hash password using SHA256 (must match registration hash method)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // ✅ CHANGED: Now returns BOTH the Role and the UserId as a Tuple
        public (string Role, int UserId) ValidateLoginAndGetDetails(string studentId, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    // Hash the password before comparing with database
                    string hashedPassword = HashPassword(password);

                    // ⬇️ CHANGED: Select u.id AND u.role
                    string query = @"
                        SELECT u.id, u.role 
                        FROM users u
                        LEFT JOIN principal p ON u.id = p.users_id AND p.employee_id = @studentId
                        LEFT JOIN teacher t ON u.id = t.users_id AND t.employee_id = @studentId
                        LEFT JOIN student s ON u.id = s.users_id AND s.student_id = @studentId
                        WHERE (p.employee_id = @studentId OR t.employee_id = @studentId OR s.student_id = @studentId)
                        AND u.password_hash = @password
                        AND u.is_active = 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        // ⬇️ CHANGED: Use ExecuteReader to grab ID and Role
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32("id");     // Get the User ID
                                string role = reader.GetString("role"); // Get the Role
                                return (role, userId);                 // Return both
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database error: " + ex.Message);
                }
            }
            return (null, 0); // Return null and 0 if login fails
        }
    }
}