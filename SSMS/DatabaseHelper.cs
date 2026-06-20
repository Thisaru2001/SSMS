using MySql.Data.MySqlClient;
using System;

namespace SSMS
{
    internal class DatabaseHelper
    {
        private string connectionString = @"Server=localhost;Database=ssmsdb;Uid=root;Pwd=root;";

        // Note: I kept the parameter name as 'studentId' so it matches your Signin.cs perfectly
        public string ValidateLoginAndGetRole(string studentId, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // UPDATED QUERY: Checks Principal, Teacher, AND Student using LEFT JOINs
                    string query = @"
                        SELECT u.role 
                        FROM users u
                        LEFT JOIN principal p ON u.id = p.users_id AND p.employee_id = @studentId
                        LEFT JOIN teacher t ON u.id = t.users_id AND t.employee_id = @studentId
                        LEFT JOIN student s ON u.id = s.users_id AND s.student_id = @studentId
                        WHERE (p.employee_id = @studentId OR t.employee_id = @studentId OR s.student_id = @studentId)
                        AND u.password_hash = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Uses '@studentId' to match your C# code
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();

                        // If a role is found, return it. Otherwise, return null.
                        return result != null ? result.ToString() : null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database error: " + ex.Message);
                    return null;
                }
            }
        }
    }
}