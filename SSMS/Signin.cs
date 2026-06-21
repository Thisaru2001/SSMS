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
            txtStudentId.Clear();
            txtPassword.Clear();
            label2.Text = "";
            txtStudentId.Focus();
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

            // 2. Validate login using DatabaseHelper (Get Role AND ID)
            DatabaseHelper dbHelper = new DatabaseHelper();
            var loginResult = dbHelper.ValidateLoginAndGetDetails(loginId, password);

            /* 
               NOTE: You must change your DatabaseHelper.cs to return TWO things:
               Method signature: public (string Role, int UserId) ValidateLoginAndGetDetails(string loginId, string password)
            */

            if (loginResult.Role != null)
            {
                label2.Text = "Login Successful!";
                label2.ForeColor = Color.Green;

                // Disable the login button so the user can't click it again while waiting
                btnLogin.Enabled = false;

                // Create a timer
                System.Windows.Forms.Timer delayTimer = new System.Windows.Forms.Timer();
                delayTimer.Interval = 2000; // 2 seconds
                delayTimer.Tick += (s, t) =>
                {
                    delayTimer.Stop();
                    delayTimer.Dispose(); // Properly dispose timer

                    // Open different dashboards based on their role!
                    Form dashboard = null;

                    switch (loginResult.Role.ToLower())
                    {
                        case "principal":
                            // ✅ PASS THE USER ID TO THE CONSTRUCTOR!
                            dashboard = new Principal_Dashbaord(loginResult.UserId);
                            break;
                        case "teacher":
                            dashboard = new Teacher_Dashbaord(); // Pass ID here if needed
                            break;
                        case "student":
                            MessageBox.Show("Student dashboard is not implemented yet.",
                                "Coming Soon",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            this.Show();
                            txtStudentId.Clear();
                            txtPassword.Clear();
                            btnLogin.Enabled = true;
                            txtStudentId.Focus();
                            return;
                        default:
                            MessageBox.Show("Unknown user role: " + loginResult.Role,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            this.Show();
                            btnLogin.Enabled = true;
                            return;
                    }

                    if (dashboard != null)
                    {
                        // Show login form again when dashboard closes
                        dashboard.FormClosed += (senderForm, args) =>
                        {
                            this.Show();
                            txtStudentId.Clear();
                            txtPassword.Clear();
                            btnLogin.Enabled = true;
                            txtStudentId.Focus();
                        };

                        dashboard.Show();
                        this.Hide();
                    }
                };

                // Start the timer
                delayTimer.Start();
            }
            else
            {
                label2.Text = "Invalid ID or Password";
                label2.ForeColor = Color.Red;
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        // Allow Enter key to trigger login
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click_1(sender, e);
            }
        }

        private void txtStudentId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
    }
}