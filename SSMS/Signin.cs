using System;
using System.Drawing;
using System.Windows.Forms;

namespace SSMS
{
    public partial class Signin : Form
    {
        public Signin()
        {
            InitializeComponent();
        }

        private void Signin_Load(object sender, EventArgs e)
        {
            txtStudentId.Clear(); // Changed from txtStudentId to match your UI
            txtPassword.Clear();
            label2.Text = "";
        }

        // Checkbox for showing/hiding password
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string loginId = txtStudentId.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 1. Check if fields are empty
            if (string.IsNullOrWhiteSpace(loginId) || string.IsNullOrWhiteSpace(password))
            {
                label2.Text = "Please fill in all fields";
                label2.ForeColor = Color.Red;
                return;
            }

            // 2. ID Format Check (Letters/Year/Number)
            if (!System.Text.RegularExpressions.Regex.IsMatch(loginId, @"^[A-Za-z]+/\d{4}/\d+$"))
            {
                label2.Text = "Invalid Format! Use: Letters/Year/ID (e.g. PS/2022/1)";
                label2.ForeColor = Color.Red;
                txtStudentId.Focus();
                txtStudentId.SelectAll();
                return;
            }

            // 3. CREATE THE HELPER AND CALL IT
            DatabaseHelper dbHelper = new DatabaseHelper();
            string userRole = dbHelper.ValidateLoginAndGetRole(loginId, password);

            if (!string.IsNullOrEmpty(userRole))
            {
                // ==========================================================
                // 🟢 LOGIN SUCCESSFUL - 4 SECOND WAIT LOGIC
                // ==========================================================

                label2.Text = "Login Successful!";
                label2.ForeColor = Color.Green;

                // Disable the login button so the user can't click it again while waiting
                btnLogin.Enabled = false;

                // Create a timer
                System.Windows.Forms.Timer delayTimer = new System.Windows.Forms.Timer();
                delayTimer.Interval = 1000; 
                delayTimer.Tick += (s, t) =>
                {
                    // This code runs AFTER 4 seconds
                    delayTimer.Stop(); // Stop the timer so it doesn't repeat

                    txtPassword.Clear();
                    txtPassword.Focus();

                    // Open different dashboards based on their role!
                    if (userRole.ToLower() == "principal")
                    {
                        Principal_Dashbaord dashboard = new Principal_Dashbaord();
                        dashboard.Show();
                    }
                    else if (userRole.ToLower() == "teacher")
                    {
                        Teacher_Dashbaord dashboard = new Teacher_Dashbaord();
                        dashboard.Show();
                    }
                    else if (userRole.ToLower() == "student")
                    {
                        // Student_Dashbaord dashboard = new Student_Dashbaord();
                        // dashboard.Show();
                    }

                    this.Hide(); // Hide login form
                };

                // Start the timer
                delayTimer.Start();
                // ==========================================================
            }
            else
            {
                label2.Text = "Invalid ID or Password";
                label2.ForeColor = Color.Red;
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}