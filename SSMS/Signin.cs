using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;   
using DotNetEnv;            

namespace SSMS
{
    public partial class Signin : Form
    {
       
        private string connectionString;

        public Signin()
        {
            InitializeComponent();
        }

        private void Signin_Load(object sender, EventArgs e)
        {
      
            try
            {
                string envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
                Env.Load(envPath);

          
                connectionString = $"server={Env.GetString("DB_HOST")};" +
                                  $"port={Env.GetString("DB_PORT")};" +
                                  $"database={Env.GetString("DB_NAME")};" +
                                  $"user={Env.GetString("DB_USER")};" +
                                  $"password={Env.GetString("DB_PASS")};";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading .env file: " + ex.Message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            string studentId = txtStudentId.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Student ID and Password.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check the database
            if (AuthenticateStudent(studentId, password))
            {
                MessageBox.Show("Login Successful! Welcome, Student.", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ====================================================
                // REDIRECT TO STUDENT DASHBOARD HERE
                // ====================================================
                // studentViewNotice dashboard = new studentViewNotice();
                // dashboard.Show();
                // this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Student ID or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to check Student ID and Password in MySQL
        private bool AuthenticateStudent(string studentId, string password)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // ⚠️ IMPORTANT: Change 'students' to your actual MySQL table name
                    // Also change 'student_id' and 'password' to your actual column names
                    string query = "SELECT COUNT(*) FROM users WHERE student_id = @studentId AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Connection Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Checkbox for showing/hiding password
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false; // Show password
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;  // Hide password with *
            }
        }
    }
}