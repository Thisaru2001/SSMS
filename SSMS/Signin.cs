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

        private string rememberMeFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ssms_login.txt");

        private void Signin_Load(object sender, EventArgs e)
        {
            txtStudentId.Clear();
            txtPassword.Clear();
            label2.Text = "";
            txtStudentId.Focus();

            
            if (System.IO.File.Exists(rememberMeFile))
            {
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(rememberMeFile);
                    if (lines.Length == 2)
                    {
                        txtStudentId.Text = lines[0];
                        txtPassword.Text = lines[1];
                        checkBox1.Checked = true;
                    }
                }
                catch { }
            }
        }

        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string loginId = txtStudentId.Text.Trim();
            string password = txtPassword.Text.Trim();

            
            if (string.IsNullOrWhiteSpace(loginId) || string.IsNullOrWhiteSpace(password))
            {
                label2.Text = "Please fill in all fields";
                label2.ForeColor = Color.Red;
                return;
            }

            
            DatabaseHelper dbHelper = new DatabaseHelper();
            var loginResult = dbHelper.ValidateLoginAndGetDetails(loginId, password);

          

            if (loginResult.Role != null)
            {
                label2.Text = "Login Successful!";
                label2.ForeColor = Color.Green;

                
                try
                {
                    if (checkBox1.Checked)
                    {
                        System.IO.File.WriteAllLines(rememberMeFile, new string[] { loginId, password });
                    }
                    else if (System.IO.File.Exists(rememberMeFile))
                    {
                        System.IO.File.Delete(rememberMeFile);
                    }
                }
                catch { }

                
                btnLogin.Enabled = false;

                
                System.Windows.Forms.Timer delayTimer = new System.Windows.Forms.Timer();
                delayTimer.Interval = 2000; 
                delayTimer.Tick += (s, t) =>
                {
                    delayTimer.Stop();
                    delayTimer.Dispose(); 

                    
                    Form dashboard = null;

                    switch (loginResult.Role.ToLower())
                    {
                        case "principal":
                            dashboard = new Principal_Dashbaord(loginResult.UserId);
                            break;
                        case "principal_assistant":
                            dashboard = new PrincipalAssistant_Dashboard(loginResult.UserId);
                            break;
                        case "teacher":
                            dashboard = new Teacher_Dashbaord(loginResult.UserId); 
                            break;
                        case "student":
                            dashboard = new Student_Dashbaord(loginResult.UserId);
                            break;
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

        private void label1_Click(object sender, EventArgs e)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Forgot Password",
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White
            };

            Label lblInfo = new Label() { Left = 20, Top = 20, Width = 340, Text = "Please enter your Student ID or Employee ID:", Font = new Font("Segoe UI", 10) };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340, Font = new Font("Segoe UI", 11), Text = txtStudentId.Text.Trim() };
            Button btnSubmit = new Button() { Text = "Reset Password", Left = 220, Width = 140, Top = 100, Height = 40, BackColor = Color.SeaGreen, ForeColor = Color.White, Font = new Font("Segoe UI", 10, FontStyle.Bold), FlatStyle = FlatStyle.Flat };
            Button btnCancel = new Button() { Text = "Cancel", Left = 60, Width = 140, Top = 100, Height = 40, BackColor = Color.LightGray, Font = new Font("Segoe UI", 10), FlatStyle = FlatStyle.Flat };

            btnSubmit.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.BorderSize = 0;

            btnSubmit.Click += (s, eArgs) => { prompt.DialogResult = DialogResult.OK; prompt.Close(); };
            btnCancel.Click += (s, eArgs) => { prompt.DialogResult = DialogResult.Cancel; prompt.Close(); };

            prompt.Controls.Add(lblInfo);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(btnSubmit);
            prompt.Controls.Add(btnCancel);
            prompt.AcceptButton = btnSubmit;
            prompt.CancelButton = btnCancel;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                string id = inputBox.Text.Trim();
                if (string.IsNullOrWhiteSpace(id)) return;

                Cursor = Cursors.WaitCursor;
                DatabaseHelper dbHelper = new DatabaseHelper();
                bool success = dbHelper.ResetPasswordAndSendEmail(id, out string message);
                Cursor = Cursors.Default;

                if (success)
                {
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}