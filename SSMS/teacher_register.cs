using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography; // For password hashing
using System.IO; // For file operations

namespace SSMS
{
    public partial class teacher_register : Form
    {
        public teacher_register()
        {
            InitializeComponent();
        }

        // FIXED: Use EnvironmentConfig instead of hardcoded connection string
        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        // ADD THIS MISSING METHOD:
        private void button1_Click(object sender, EventArgs e)
        {
            // Add your logic for button1 here
        }

        // ADD THIS MISSING METHOD:
        private void label1_Click(object sender, EventArgs e)
        {
            // Add your logic for label1 here
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
        {// Make sure first name and last name are filled
         // Make sure first name and last name are filled
            if (string.IsNullOrWhiteSpace(txtFname.Text) || string.IsNullOrWhiteSpace(txtLname.Text))
            {
                MessageBox.Show("First Name and Last Name are required to generate an ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generate Employee ID in format: ROLE/YEAR/COUNT
            string rolePrefix = "TC"; // TC for Teacher
            string yearPart = DateTime.Now.Year.ToString(); // Current year (2026)

            // Get the next count from database for this role and year
            string countPart = GetNextEmployeeCount(rolePrefix, yearPart);

            string schoolId = rolePrefix + "/" + yearPart + "/" + countPart;

            // Display the ID in the Label
            vid.Text = schoolId;
            vid.ForeColor = Color.SeaGreen;

            // Enable the Submit button
            submitBtn.Visible = true;

            // Disable the Generate button so they can't change it
            gnsid.Enabled = false;
        }

        // Get the next sequential number for the role and year
        private string GetNextEmployeeCount(string rolePrefix, string year)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    // Count existing teachers with same role prefix and year pattern
                    string query = @"SELECT COUNT(*) + 1 
                           FROM teacher 
                           WHERE employee_id LIKE @pattern";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Pattern match: TC/2026/%
                        cmd.Parameters.AddWithValue("@pattern", rolePrefix + "/" + year + "/%");

                        int nextCount = Convert.ToInt32(cmd.ExecuteScalar());

                        // Format as 3-digit number (001, 002, etc.)
                        return nextCount.ToString("D3");
                    }
                }
                catch (Exception ex)
                {
                    // If database error, use random number as fallback
                    MessageBox.Show("Could not generate sequential ID. Using random ID instead.\nError: " + ex.Message,
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    Random rand = new Random();
                    return rand.Next(1, 999).ToString("D3");
                }
            }
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            // Validate all fields before submission
            if (!ValidateAllFields())
            {
                return;
            }

            // Check for duplicate entries
            if (!CheckDuplicateEntries())
            {
                return;
            }

            try
            {
                // Save to MySQL database
                if (SaveTeacherToMySQL())
                {
                    // Show the final success message
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

        // Check for duplicate NIC, Email, and Phone
        private bool CheckDuplicateEntries()
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    // Check for duplicate NIC
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

                    // Check for duplicate Email
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

                    // Check for duplicate Phone
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

                    return true; // No duplicates found
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking duplicates: " + ex.Message, "Database Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // Comprehensive validation method
        private bool ValidateAllFields()
        {
            // Validate First Name
            if (string.IsNullOrWhiteSpace(txtFname.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFname.Focus();
                return false;
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(txtLname.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLname.Focus();
                return false;
            }

            // Validate NIC
            if (string.IsNullOrWhiteSpace(txtNic.Text))
            {
                MessageBox.Show("NIC Number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNic.Focus();
                return false;
            }

            // NIC Format Validation (Basic check for length)
            if (txtNic.Text.Length < 10 || txtNic.Text.Length > 12)
            {
                MessageBox.Show("Please enter a valid NIC number (10-12 characters).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNic.Focus();
                return false;
            }

            // Validate Address
            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                MessageBox.Show("Address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAd.Focus();
                return false;
            }

            // Validate Gender Selection
            if (!rbMale.Checked && !rbFemale.Checked)
            {
                MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Advanced Email Validation using Regex
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address.\nExample: username@domain.com", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Validate Contact Number
            if (string.IsNullOrWhiteSpace(txtCn.Text))
            {
                MessageBox.Show("Contact Number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCn.Focus();
                return false;
            }

            // Contact Number Format Validation (Only digits, 10-11 characters)
            string contactPattern = @"^\d{10,11}$";
            if (!Regex.IsMatch(txtCn.Text, contactPattern))
            {
                MessageBox.Show("Please enter a valid contact number (10-11 digits only).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCn.Focus();
                return false;
            }

            // Validate Date of Birth
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

            // Validate School ID is generated
            if (string.IsNullOrWhiteSpace(vid.Text))
            {
                MessageBox.Show("Please generate a School ID first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Generate default password hash
        private string GenerateDefaultPassword()
        {
            string defaultPassword = "admin123";
            return HashPassword(defaultPassword);
        }

        // FIXED: Make HashPassword public static so DatabaseHelper can use it
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

        // MySQL database save method - Matches your database structure
        private bool SaveTeacherToMySQL()
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                connection.Open();

                // Start a transaction to ensure both inserts succeed or both fail
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // First: Insert into users table
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

                            // Handle image path
                            string imagePath = SaveProfileImage();
                            userCommand.Parameters.AddWithValue("@image_path", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);

                            userCommand.Parameters.AddWithValue("@is_active", 1);

                            userId = Convert.ToInt32(userCommand.ExecuteScalar());
                        }

                        // Second: Insert into teacher table
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

                        // Commit transaction
                        transaction.Commit();

                        MessageBox.Show($"Teacher registered successfully!\n\nDefault Password: admin123\n\nPlease inform the teacher to change password after first login.",
                                      "Registration Complete",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);

                        return true;
                    }
                    catch (Exception)
                    {
                        // Rollback if any error occurs
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // Save profile image to folder and return path
        private string SaveProfileImage()
        {
            if (pf.Image == null)
                return null;

            try
            {
                // Create directory if it doesn't exist
                string imagesFolder = Path.Combine(Application.StartupPath, "ProfileImages");
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                // FIXED: Replace invalid filename characters (/ \ : * ? " < > |)
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

                // Save image
                pf.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Return relative path for database
                return $"ProfileImages/{fileName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save profile image: " + ex.Message, "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        // Clear all fields for new registration
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
            // Check if all required fields on Tab 1 are filled
            if (string.IsNullOrWhiteSpace(txtFname.Text) ||
                string.IsNullOrWhiteSpace(txtLname.Text) ||
                string.IsNullOrWhiteSpace(txtNic.Text) ||
                string.IsNullOrWhiteSpace(txtAd.Text) ||
                (!rbMale.Checked && !rbFemale.Checked))
            {
                MessageBox.Show("Please fill in all fields and select a gender before proceeding.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for duplicate NIC when clicking Next
            if (!CheckNICDuplicate())
            {
                return;
            }

            // Move to the next tab (Index 1 is the second tab)
            tabControl1.SelectedIndex = 1;

            // Disable the Next button so they can't go back
            nextBtn.Enabled = false;
        }

        // Check NIC duplicate on Next button click
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

        // Real-time NIC validation when leaving the field
        private void txtNic_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNic.Text) && txtNic.Text.Length >= 10)
            {
                CheckNICDuplicate();
            }
        }

        // Real-time Email validation when leaving the field
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

        // Real-time Phone validation when leaving the field
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
            // Hide the Submit button at the start
            submitBtn.Visible = false;

            // Make sure the ID label starts empty
            vid.Text = "";

            // Set the TabControl to start on the first tab
            tabControl1.SelectedIndex = 0;

            // Set a default placeholder image or border so it looks like a photo frame
            pf.BorderStyle = BorderStyle.FixedSingle;
            pf.SizeMode = PictureBoxSizeMode.Zoom;

            // Attach Leave events for real-time validation
            txtNic.Leave += txtNic_Leave;
            txtEmail.Leave += txtEmail_Leave;
            txtCn.Leave += txtCn_Leave;
        }

        // Image selection
        private void pf_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to let the user pick a picture from their computer
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Only show image files
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Select Profile Image";

                // If the user picks a file and clicks "OK"
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load the image directly from the file path into the PictureBox
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