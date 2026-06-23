using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Data;

namespace SSMS
{
    internal class DatabaseHelper
    {
        
        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

    
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

        
        public (string Role, int UserId) ValidateLoginAndGetDetails(string studentId, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    
                    string hashedPassword = HashPassword(password);

                    
                    string query = @"
                        SELECT u.id, u.role 
                        FROM users u
                        LEFT JOIN principal p ON u.id = p.users_id AND p.employee_id = @studentId
                        LEFT JOIN principal_assistant pa ON u.id = pa.users_id AND pa.employee_id = @studentId
                        LEFT JOIN teacher t ON u.id = t.users_id AND t.employee_id = @studentId
                        LEFT JOIN student s ON u.id = s.users_id AND s.student_id = @studentId
                        WHERE (p.employee_id = @studentId OR pa.employee_id = @studentId OR t.employee_id = @studentId OR s.student_id = @studentId)
                        AND u.password_hash = @password
                        AND u.is_active = 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32("id");     
                                string role = reader.GetString("role"); 
                                return (role, userId);                 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database error: " + ex.Message);
                }
            }
            return (null, 0); 
        }

        public bool ResetPasswordAndSendEmail(string employeeOrStudentId, out string message)
        {
            string email = null;
            int userId = 0;
            string firstname = "";

            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    
                    string query = @"
                        SELECT u.id, u.email, u.firstname 
                        FROM users u
                        LEFT JOIN principal p ON u.id = p.users_id AND p.employee_id = @id
                        LEFT JOIN principal_assistant pa ON u.id = pa.users_id AND pa.employee_id = @id
                        LEFT JOIN teacher t ON u.id = t.users_id AND t.employee_id = @id
                        LEFT JOIN student s ON u.id = s.users_id AND s.student_id = @id
                        WHERE (p.employee_id = @id OR pa.employee_id = @id OR t.employee_id = @id OR s.student_id = @id)
                        AND u.is_active = 1 LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", employeeOrStudentId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userId = reader.GetInt32("id");
                                if (!reader.IsDBNull(reader.GetOrdinal("email")))
                                    email = reader.GetString("email");
                                firstname = reader.GetString("firstname");
                            }
                        }
                    }

                    if (userId == 0)
                    {
                        message = "User ID not found or inactive.";
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(email))
                    {
                        message = "No email address registered for this user.";
                        return false;
                    }

                    
                    string newPassword = "admin123";
                    string hashedPassword = HashPassword(newPassword);

                    
                    string updateQuery = "UPDATE users SET password_hash = @hash WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@hash", hashedPassword);
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                    }

                    
                    EnvironmentConfig.Load();
                    string smtpServer = EnvironmentConfig.GetVariable("SMTP_SERVER") ?? "smtp.gmail.com";
                    string smtpPortStr = EnvironmentConfig.GetVariable("SMTP_PORT") ?? "587";
                    int smtpPort = int.TryParse(smtpPortStr, out int p) ? p : 587;
                    string smtpUser = EnvironmentConfig.GetVariable("SMTP_USER");
                    string smtpPass = EnvironmentConfig.GetVariable("SMTP_PASS");

                    if (string.IsNullOrWhiteSpace(smtpUser) || smtpUser == "your_email@gmail.com")
                    {
                        message = "SMTP email configuration is missing in .env file.";
                        return false;
                    }

                    try
                    {
                        using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(smtpServer, smtpPort))
                        {
                            client.UseDefaultCredentials = false;
                            client.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);
                            client.EnableSsl = true;

                            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                            mail.From = new System.Net.Mail.MailAddress(smtpUser, "SSMS Admin");
                            mail.To.Add(email);
                            mail.Subject = "SSMS Password Reset";
                            mail.Body = $"Hello {firstname},\n\nYour password has been successfully reset.\n\nYour new temporary password is: {newPassword}\n\nPlease login and change it as soon as possible.";

                            client.Send(mail);
                        }
                        message = "A temporary password has been sent to your registered email address.";
                    }
                    catch (Exception emailEx)
                    {
                        Console.WriteLine("Failed to send email: " + emailEx.Message);
                        message = $"Password was successfully reset to: {newPassword}\n\n(However, we failed to send the notification email to {email})";
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    message = "Error: " + ex.Message;
                    return false;
                }
            }
        }

        public static DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            EnvironmentConfig.Load();
            string connString = EnvironmentConfig.GetConnectionString();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        public static void ExecuteNonQuery(string query)
        {
            EnvironmentConfig.Load();
            string connString = EnvironmentConfig.GetConnectionString();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}