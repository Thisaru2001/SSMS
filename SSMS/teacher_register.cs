using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography; 
using System.IO; 

namespace SSMS
{
    public partial class teacher_register : Form
    {
        public teacher_register()
        {
            InitializeComponent();
        }

        
        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void gnsid_Click(object sender, EventArgs e)
        {
         
            if (string.IsNullOrWhiteSpace(txtFname.Text) || string.IsNullOrWhiteSpace(txtLname.Text))
            {
                MessageBox.Show("First Name and Last Name are required to generate an ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string rolePrefix = "TC"; 
            string yearPart = DateTime.Now.Year.ToString(); 

            
            string countPart = GetNextEmployeeCount(rolePrefix, yearPart);

            string schoolId = rolePrefix + "/" + yearPart + "/" + countPart;

            
            vid.Text = schoolId;
            vid.ForeColor = Color.SeaGreen;

            
            submitBtn.Visible = true;

            
            gnsid.Enabled = false;
        }

        
        private string GetNextEmployeeCount(string rolePrefix, string year)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    
                    string query = @"SELECT COUNT(*) + 1 
                           FROM teacher 
                           WHERE employee_id LIKE @pattern";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        
                        cmd.Parameters.AddWithValue("@pattern", rolePrefix + "/" + year + "/%");

                        int nextCount = Convert.ToInt32(cmd.ExecuteScalar());

                        
                        return nextCount.ToString("D3");
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Could not generate sequential ID. Using random ID instead.\nError: " + ex.Message,
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    Random rand = new Random();
                    return rand.Next(1, 999).ToString("D3");
                }
            }
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            
            if (!ValidateAllFields())
            {
                return;
            }

            
            if (!CheckDuplicateEntries())
            {
                return;
            }

            try
            {
                
                if (SaveTeacherToMySQL())
                {
                    
                    DialogResult result = MessageBox.Show(
                        "Registration Complete!\nTeacher ID: " + vid.Text + "\n\nDo you want to register another teacher?",
                        "Success",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (result == DialogResult.Yes)
                    {
                        ClearAllFields();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private bool CheckDuplicateEntries()
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    
                    string nicQuery = "SELECT COUNT(*) FROM users WHERE nic = @nic";
                    using (MySqlCommand nicCommand = new MySqlCommand(nicQuery, connection))
                    {
                        nicCommand.Parameters.AddWithValue("@nic", txtNic.Text.Trim());
                        int nicCount = Convert.ToInt32(nicCommand.ExecuteScalar());

                        if (nicCount > 0)
                        {
                            MessageBox.Show("This NIC number is already registered!\nPlease use a different NIC.",
                                          "Duplicate NIC",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                            txtNic.Focus();
                            return false;
                        }
                    }

                    
                    string emailQuery = "SELECT COUNT(*) FROM users WHERE email = @email";
                    using (MySqlCommand emailCommand = new MySqlCommand(emailQuery, connection))
                    {
                        emailCommand.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        int emailCount = Convert.ToInt32(emailCommand.ExecuteScalar());

                        if (emailCount > 0)
                        {
                            MessageBox.Show("This Email address is already registered!\nPlease use a different email.",
                                          "Duplicate Email",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                            txtEmail.Focus();
                            return false;
                        }
                    }

                    
                    string phoneQuery = "SELECT COUNT(*) FROM users WHERE phone = @phone";
                    using (MySqlCommand phoneCommand = new MySqlCommand(phoneQuery, connection))
                    {
                        phoneCommand.Parameters.AddWithValue("@phone", txtCn.Text.Trim());
                        int phoneCount = Convert.ToInt32(phoneCommand.ExecuteScalar());

                        if (phoneCount > 0)
                        {
                            MessageBox.Show("This Phone number is already registered!\nPlease use a different phone number.",
                                          "Duplicate Phone",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                            txtCn.Focus();
                            return false;
                        }
                    }

                    return true; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking duplicates: " + ex.Message, "Database Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        
        private bool ValidateAllFields()
        {
            
            if (string.IsNullOrWhiteSpace(txtFname.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFname.Focus();
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(txtLname.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLname.Focus();
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(txtNic.Text))
            {
                MessageBox.Show("NIC Number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNic.Focus();
                return false;
            }

            
            if (txtNic.Text.Length < 10 || txtNic.Text.Length > 12)
            {
                MessageBox.Show("Please enter a valid NIC number (10-12 characters).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNic.Focus();
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                MessageBox.Show("Address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAd.Focus();
                return false;
            }

            
            if (!rbMale.Checked && !rbFemale.Checked)
            {
                MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address.\nExample: username@domain.com", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(txtCn.Text))
            {
                MessageBox.Show("Contact Number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCn.Focus();
                return false;
            }

            
            string contactPattern = @"^\d{10,11}$";
            if (!Regex.IsMatch(txtCn.Text, contactPattern))
            {
                MessageBox.Show("Please enter a valid contact number (10-11 digits only).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCn.Focus();
                return false;
            }

            
            if (dtpDob.Value > DateTime.Now.AddYears(-18))
            {
                MessageBox.Show("Teacher must be at least 18 years old.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDob.Focus();
                return false;
            }

            if (dtpDob.Value < DateTime.Now.AddYears(-100))
            {
                MessageBox.Show("Please enter a valid date of birth.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDob.Focus();
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(vid.Text))
            {
                MessageBox.Show("Please generate a School ID first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        
        private string GenerateDefaultPassword()
        {
            string defaultPassword = "admin123";
            return HashPassword(defaultPassword);
        }

        
        public static string HashPassword(string password)
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

        
        private bool SaveTeacherToMySQL()
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                connection.Open();

                
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        
                        string userQuery = @"INSERT INTO users 
                                            (role, firstname, lastname, email, password_hash, nic, phone, 
                                             address, gender, date_of_birth, image_path, is_active) 
                                            VALUES 
                                            (@role, @firstname, @lastname, @email, @password_hash, @nic, @phone, 
                                             @address, @gender, @date_of_birth, @image_path, @is_active);
                                            SELECT LAST_INSERT_ID();";

                        int userId;
                        using (MySqlCommand userCommand = new MySqlCommand(userQuery, connection, transaction))
                        {
                            userCommand.Parameters.AddWithValue("@role", "teacher");
                            userCommand.Parameters.AddWithValue("@firstname", txtFname.Text.Trim());
                            userCommand.Parameters.AddWithValue("@lastname", txtLname.Text.Trim());
                            userCommand.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                            userCommand.Parameters.AddWithValue("@password_hash", GenerateDefaultPassword());
                            userCommand.Parameters.AddWithValue("@nic", txtNic.Text.Trim());
                            userCommand.Parameters.AddWithValue("@phone", txtCn.Text.Trim());
                            userCommand.Parameters.AddWithValue("@address", txtAd.Text.Trim());
                            userCommand.Parameters.AddWithValue("@gender", rbMale.Checked ? "Male" : "Female");
                            userCommand.Parameters.AddWithValue("@date_of_birth", dtpDob.Value.ToString("yyyy-MM-dd"));

                            
                            string imagePath = SaveProfileImage();
                            userCommand.Parameters.AddWithValue("@image_path", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);

                            userCommand.Parameters.AddWithValue("@is_active", 1);

                            userId = Convert.ToInt32(userCommand.ExecuteScalar());
                        }

                        
                        string teacherQuery = @"INSERT INTO teacher 
                                               (users_id, employee_id, qualification) 
                                               VALUES 
                                               (@users_id, @employee_id, @qualification)";

                        using (MySqlCommand teacherCommand = new MySqlCommand(teacherQuery, connection, transaction))
                        {
                            teacherCommand.Parameters.AddWithValue("@users_id", userId);
                            teacherCommand.Parameters.AddWithValue("@employee_id", vid.Text);
                            teacherCommand.Parameters.AddWithValue("@qualification", "Not Specified");

                            teacherCommand.ExecuteNonQuery();
                        }

                        
                        transaction.Commit();

                        MessageBox.Show($"Teacher registered successfully!\n\nDefault Password: admin123\n\nPlease inform the teacher to change password after first login.",
                                      "Registration Complete",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);

                        return true;
                    }
                    catch (Exception)
                    {
                        
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        
        private string SaveProfileImage()
        {
            if (pf.Image == null)
                return null;

            try
            {
                
                string imagesFolder = Path.Combine(Application.StartupPath, "ProfileImages");
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                
                string safeId = vid.Text
                    .Replace("/", "_")
                    .Replace("\\", "_")
                    .Replace(":", "_")
                    .Replace("*", "_")
                    .Replace("?", "_")
                    .Replace("\"", "_")
                    .Replace("<", "_")
                    .Replace(">", "_")
                    .Replace("|", "_");

                string fileName = $"teacher_{safeId}_{DateTime.Now:yyyyMMddHHmmss}.jpg";
                string filePath = Path.Combine(imagesFolder, fileName);

                
                pf.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                
                return $"ProfileImages/{fileName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save profile image: " + ex.Message, "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        
        private void ClearAllFields()
        {
            txtFname.Clear();
            txtLname.Clear();
            txtNic.Clear();
            txtAd.Clear();
            txtEmail.Clear();
            txtCn.Clear();
            vid.Text = "";
            pf.Image = null;
            rbMale.Checked = false;
            rbFemale.Checked = false;
            dtpDob.Value = DateTime.Now;
            gnsid.Enabled = true;
            submitBtn.Visible = false;
            tabControl1.SelectedIndex = 0;
            nextBtn.Enabled = true;
            txtFname.Focus();
        }

        private void nextbtn_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtFname.Text) ||
                string.IsNullOrWhiteSpace(txtLname.Text) ||
                string.IsNullOrWhiteSpace(txtNic.Text) ||
                string.IsNullOrWhiteSpace(txtAd.Text) ||
                (!rbMale.Checked && !rbFemale.Checked))
            {
                MessageBox.Show("Please fill in all fields and select a gender before proceeding.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (!CheckNICDuplicate())
            {
                return;
            }

            
            tabControl1.SelectedIndex = 1;

            
            nextBtn.Enabled = false;
        }

        
        private bool CheckNICDuplicate()
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    string nicQuery = "SELECT COUNT(*) FROM users WHERE nic = @nic";
                    using (MySqlCommand nicCommand = new MySqlCommand(nicQuery, connection))
                    {
                        nicCommand.Parameters.AddWithValue("@nic", txtNic.Text.Trim());
                        int nicCount = Convert.ToInt32(nicCommand.ExecuteScalar());

                        if (nicCount > 0)
                        {
                            MessageBox.Show("This NIC number is already registered!\nPlease use a different NIC.",
                                          "Duplicate NIC",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                            txtNic.Focus();
                            return false;
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking NIC: " + ex.Message, "Database Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        
        private void txtNic_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNic.Text) && txtNic.Text.Length >= 10)
            {
                CheckNICDuplicate();
            }
        }

        
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && txtEmail.Text.Contains("@"))
            {
                using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
                {
                    try
                    {
                        connection.Open();

                        string emailQuery = "SELECT COUNT(*) FROM users WHERE email = @email";
                        using (MySqlCommand emailCommand = new MySqlCommand(emailQuery, connection))
                        {
                            emailCommand.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                            int emailCount = Convert.ToInt32(emailCommand.ExecuteScalar());

                            if (emailCount > 0)
                            {
                                MessageBox.Show("This Email address is already registered!\nPlease use a different email.",
                                              "Duplicate Email",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Warning);
                                txtEmail.Focus();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error checking email: " + ex.Message, "Database Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        
        private void txtCn_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCn.Text) && txtCn.Text.Length >= 10)
            {
                using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
                {
                    try
                    {
                        connection.Open();

                        string phoneQuery = "SELECT COUNT(*) FROM users WHERE phone = @phone";
                        using (MySqlCommand phoneCommand = new MySqlCommand(phoneQuery, connection))
                        {
                            phoneCommand.Parameters.AddWithValue("@phone", txtCn.Text.Trim());
                            int phoneCount = Convert.ToInt32(phoneCommand.ExecuteScalar());

                            if (phoneCount > 0)
                            {
                                MessageBox.Show("This Phone number is already registered!\nPlease use a different phone number.",
                                              "Duplicate Phone",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Warning);
                                txtCn.Focus();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error checking phone: " + ex.Message, "Database Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void f_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void m_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void teacher_register_Load(object sender, EventArgs e)
        {
            
            submitBtn.Visible = false;

            
            vid.Text = "";

            
            tabControl1.SelectedIndex = 0;

            
            pf.BorderStyle = BorderStyle.FixedSingle;
            pf.SizeMode = PictureBoxSizeMode.Zoom;

            
            txtNic.Leave += txtNic_Leave;
            txtEmail.Leave += txtEmail_Leave;
            txtCn.Leave += txtCn_Leave;
        }

        
        private void pf_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Select Profile Image";

                
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        
                        pf.Image = Image.FromFile(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}