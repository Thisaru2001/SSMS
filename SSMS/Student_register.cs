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
    public partial class Student_register : Form
    {
        private string _editStudentId = "";
        private bool _isEditMode = false;

        public Student_register()
        {
            InitializeComponent();
        }

        public Student_register(string studentId, bool editMode)
        {
            _editStudentId = studentId;
            _isEditMode = editMode;
            InitializeComponent();
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void Student_register_Load(object sender, EventArgs e)
        {
            button4.Visible = false;
            label19.Text = "";
            tabControl1.SelectedIndex = 0;

           
            LoadSections();
            LoadRelationships();
            LoadGenders();

            pbStudentPhoto.BorderStyle = BorderStyle.FixedSingle;
            pbStudentPhoto.SizeMode = PictureBoxSizeMode.Zoom;

            dtpDOB.Value = DateTime.Now.AddYears(-10);

            NIC.Leave += NIC_Leave;
            textBox7.Leave += textBox7_Leave;
            textBox5.Leave += textBox5_Leave;

            if (_isEditMode && !string.IsNullOrEmpty(_editStudentId))
            {
                this.Text = "Update Student";
                LoadStudentData();
            }
        }

        private void LoadStudentData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = @"SELECT u.*, s.*, g.grade_name 
                                     FROM student s 
                                     JOIN users u ON s.users_id = u.id 
                                     JOIN grade g ON s.grade_id = g.id
                                     WHERE s.student_id = @studentId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", _editStudentId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                label19.Text = reader["student_id"].ToString();
                                txtStudentName.Text = reader["firstname"].ToString();
                                textBox1.Text = reader["lastname"].ToString();
                                dtpDOB.Value = reader["date_of_birth"] != DBNull.Value ? Convert.ToDateTime(reader["date_of_birth"]) : DateTime.Now;
                                cmbSection.SelectedItem = reader["gender"].ToString();
                                NIC.Text = reader["nic"].ToString();
                                textBox7.Text = reader["email"].ToString();
                                textBox2.Text = reader["address"].ToString();

                                string parentName = reader["parent_name"].ToString();
                                string[] names = parentName.Split(' ');
                                if (names.Length > 0) textBox6.Text = names[0];
                                if (names.Length > 1) textBox4.Text = names[1];

                                string imagePath = reader["image_path"].ToString();
                                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                                {
                                    pbStudentPhoto.Image = System.Drawing.Image.FromFile(imagePath);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        
        
        
        
        
        
        

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        

        private void LoadSections()
        {
            comboBox4.Items.Clear();
            comboBox4.Items.Add("A");
            comboBox4.Items.Add("B");
            comboBox4.Items.Add("C");
            comboBox4.Items.Add("D");
            comboBox4.SelectedIndex = 0;
        }

        private void LoadRelationships()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Father");
            comboBox2.Items.Add("Mother");
            comboBox2.Items.Add("Guardian");
            comboBox2.Items.Add("Other");
            comboBox2.SelectedIndex = 0;
        }

        private void LoadGenders()
        {
            cmbSection.Items.Clear();
            cmbSection.Items.Add("Male");
            cmbSection.Items.Add("Female");
            cmbSection.SelectedIndex = 0;

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
            comboBox1.SelectedIndex = 0;
        }

        private class GradeItem
        {
            public int Id { get; set; }
            public string DisplayText { get; set; } = string.Empty;
            public override string ToString() { return DisplayText; }
        }

        
        private void pbStudentPhoto_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Select Student Photo";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pbStudentPhoto.Image = Image.FromFile(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentName.Text) || comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Student Name and Grade are required to generate an ID.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rolePrefix = "SU";
            string yearPart = DateTime.Now.Year.ToString();
            string countPart = GetNextStudentCount(rolePrefix, yearPart);

            string studentId = $"{rolePrefix}/{yearPart}/{countPart}";

            label19.Text = studentId;
            label19.ForeColor = Color.SeaGreen;

            button4.Visible = true;
            button3.Enabled = false;
        }

        private string GetNextStudentCount(string rolePrefix, string year)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) + 1 FROM student WHERE student_id LIKE @pattern";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pattern", $"{rolePrefix}/{year}/%");
                        int nextCount = Convert.ToInt32(cmd.ExecuteScalar());
                        return nextCount.ToString("D3");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating ID: " + ex.Message, "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new Random().Next(1, 999).ToString("D3");
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!ValidatePersonalInfo()) return;
            tabControl1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateGuardianInfo()) return;
            tabControl1.SelectedIndex = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ValidateAcademicInfo()) return;
            tabControl1.SelectedIndex = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!ValidateAllFields()) return;
            if (!_isEditMode && !CheckDuplicateEntries()) return;

            try
            {
                if (_isEditMode)
                {
                    if (UpdateStudentToMySQL())
                    {
                        MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    if (SaveStudentToMySQL())
                    {
                        DialogResult result = MessageBox.Show(
                            $"Registration Complete!\n\nStudent ID: {label19.Text}\n" +
                            $"Name: {txtStudentName.Text} {textBox1.Text}\n" +
                            $"Guardian: {textBox6.Text} {textBox4.Text}\n" +
                            $"Grade: {comboBox3.SelectedItem}\n\n" +
                            $"Default Password: admin123\n\nRegister another student?",
                            "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                            ClearAllFields();
                        else
                            this.Close();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidatePersonalInfo()
        {
            if (string.IsNullOrWhiteSpace(txtStudentName.Text))
            { ShowValidationError("Student First Name is required.", txtStudentName); return false; }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            { ShowValidationError("Address is required.", textBox2); return false; }

            if (dtpDOB.Value > DateTime.Now.AddYears(-5))
            { MessageBox.Show("Student must be at least 5 years old.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); dtpDOB.Focus(); return false; }

            if (dtpDOB.Value < DateTime.Now.AddYears(-25))
            { MessageBox.Show("Please enter a valid date of birth.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); dtpDOB.Focus(); return false; }

            return true;
        }

        private bool ValidateGuardianInfo()
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            { ShowValidationError("Guardian First Name is required.", textBox6); return false; }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            { ShowValidationError("Guardian Last Name is required.", textBox4); return false; }

            if (string.IsNullOrWhiteSpace(textBox7.Text))
            { ShowValidationError("Guardian Email is required.", textBox7); return false; }

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(textBox7.Text, emailPattern))
            { ShowValidationError("Please enter a valid guardian email address.", textBox7); return false; }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            { ShowValidationError("Guardian Address is required.", textBox3); return false; }

            return true;
        }

        private bool ValidateAcademicInfo()
        {
            if (comboBox3.SelectedIndex == -1)
            { MessageBox.Show("Please select a grade to enroll.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); comboBox3.Focus(); return false; }

            if (comboBox4.SelectedIndex == -1)
            { MessageBox.Show("Please select a section.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); comboBox4.Focus(); return false; }

            return true;
        }

        private bool ValidateAllFields()
        {
            if (string.IsNullOrWhiteSpace(label19.Text))
            { MessageBox.Show("Please generate a Student ID first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            return true;
        }

        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private bool CheckDuplicateEntries()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    if (!string.IsNullOrWhiteSpace(NIC.Text))
                    {
                        string query = "SELECT COUNT(*) FROM users WHERE nic = @nic";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nic", NIC.Text.Trim());
                            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                            { MessageBox.Show("This Student NIC is already registered!", "Duplicate NIC", MessageBoxButtons.OK, MessageBoxIcon.Warning); NIC.Focus(); return false; }
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(textBox7.Text))
                    {
                        string query = "SELECT COUNT(*) FROM users WHERE email = @email";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@email", textBox7.Text.Trim());
                            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                            { MessageBox.Show("This Email is already registered!", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox7.Focus(); return false; }
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(textBox5.Text))
                    {
                        string query = "SELECT COUNT(*) FROM users WHERE nic = @nic";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nic", textBox5.Text.Trim());
                            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                            { MessageBox.Show("This Guardian NIC is already registered!", "Duplicate NIC", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox5.Focus(); return false; }
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                { MessageBox.Show("Error checking duplicates: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }

        private bool SaveStudentToMySQL()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string userQuery = @"INSERT INTO users 
                            (role, firstname, lastname, email, password_hash, nic, phone, address, gender, date_of_birth, image_path, is_active) 
                            VALUES (@role, @firstname, @lastname, @email, @password_hash, @nic, @phone, @address, @gender, @date_of_birth, @image_path, @is_active);
                            SELECT LAST_INSERT_ID();";

                        int userId;
                        using (MySqlCommand cmd = new MySqlCommand(userQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@role", "student");
                            cmd.Parameters.AddWithValue("@firstname", txtStudentName.Text.Trim());
                            cmd.Parameters.AddWithValue("@lastname", textBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", textBox7.Text.Trim());
                            cmd.Parameters.AddWithValue("@password_hash", HashPassword("admin123"));
                            cmd.Parameters.AddWithValue("@nic", string.IsNullOrWhiteSpace(NIC.Text) ? (object)DBNull.Value : NIC.Text.Trim());
                            cmd.Parameters.AddWithValue("@phone", "");
                            cmd.Parameters.AddWithValue("@address", textBox2.Text.Trim());
                            cmd.Parameters.AddWithValue("@gender", cmbSection.SelectedItem?.ToString() ?? "Male");
                            cmd.Parameters.AddWithValue("@date_of_birth", dtpDOB.Value.ToString("yyyy-MM-dd"));

                            string imagePath = SaveProfileImage();
                            cmd.Parameters.AddWithValue("@image_path", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);
                            cmd.Parameters.AddWithValue("@is_active", 1);

                            userId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        int gradeId = GetGradeId(comboBox3.SelectedItem?.ToString() ?? "", comboBox4.SelectedItem?.ToString() ?? "");

                        string studentQuery = @"INSERT INTO student 
                            (users_id, student_id, roll_no, grade_id, parent_name, enrolled_at) 
                            VALUES (@users_id, @student_id, @roll_no, @grade_id, @parent_name, @enrolled_at)";

                        using (MySqlCommand cmd = new MySqlCommand(studentQuery, conn, transaction))
                        {
                            string guardianFullName = $"{textBox6.Text.Trim()} {textBox4.Text.Trim()}";

                            cmd.Parameters.AddWithValue("@users_id", userId);
                            cmd.Parameters.AddWithValue("@student_id", label19.Text);
                            cmd.Parameters.AddWithValue("@roll_no", DBNull.Value);
                            cmd.Parameters.AddWithValue("@grade_id", gradeId);
                            cmd.Parameters.AddWithValue("@parent_name", guardianFullName);
                            cmd.Parameters.AddWithValue("@enrolled_at", DateTime.Now.ToString("yyyy-MM-dd"));
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show($"Student registered successfully!\n\nStudent ID: {label19.Text}\nName: {txtStudentName.Text} {textBox1.Text}\nGrade: {comboBox3.SelectedItem}\nGuardian: {textBox6.Text} {textBox4.Text}\n\nDefault Password: admin123", "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool UpdateStudentToMySQL()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string userQuery = @"UPDATE users u
                                             JOIN student s ON u.id = s.users_id
                                             SET u.firstname = @firstname, 
                                                 u.lastname = @lastname, 
                                                 u.email = @email, 
                                                 u.nic = @nic, 
                                                 u.address = @address, 
                                                 u.gender = @gender, 
                                                 u.date_of_birth = @date_of_birth
                                             WHERE s.student_id = @student_id";

                        using (MySqlCommand cmd = new MySqlCommand(userQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@student_id", _editStudentId);
                            cmd.Parameters.AddWithValue("@firstname", txtStudentName.Text.Trim());
                            cmd.Parameters.AddWithValue("@lastname", textBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", textBox7.Text.Trim());
                            cmd.Parameters.AddWithValue("@nic", string.IsNullOrWhiteSpace(NIC.Text) ? (object)DBNull.Value : NIC.Text.Trim());
                            cmd.Parameters.AddWithValue("@address", textBox2.Text.Trim());
                            cmd.Parameters.AddWithValue("@gender", cmbSection.SelectedItem?.ToString() ?? "Male");
                            cmd.Parameters.AddWithValue("@date_of_birth", dtpDOB.Value.ToString("yyyy-MM-dd"));
                            cmd.ExecuteNonQuery();
                        }

                        
                        string imagePath = SaveProfileImage();
                        if (!string.IsNullOrEmpty(imagePath))
                        {
                            string imgQuery = "UPDATE users u JOIN student s ON u.id = s.users_id SET u.image_path = @img WHERE s.student_id = @student_id";
                            using (MySqlCommand cmd = new MySqlCommand(imgQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@student_id", _editStudentId);
                                cmd.Parameters.AddWithValue("@img", imagePath);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        int gradeId = GetGradeId(comboBox3.SelectedItem?.ToString() ?? "", comboBox4.SelectedItem?.ToString() ?? "");
                        string guardianFullName = $"{textBox6.Text.Trim()} {textBox4.Text.Trim()}";

                        string studentQuery = @"UPDATE student 
                                                SET grade_id = @grade_id, 
                                                    parent_name = @parent_name 
                                                WHERE student_id = @student_id";

                        using (MySqlCommand cmd = new MySqlCommand(studentQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@student_id", _editStudentId);
                            cmd.Parameters.AddWithValue("@grade_id", gradeId);
                            cmd.Parameters.AddWithValue("@parent_name", guardianFullName);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
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

        private int GetGradeId(string gradeDisplayText, string section)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                conn.Open();
                string gradeName = "";
                if (gradeDisplayText.Contains("Grade "))
                    gradeName = gradeDisplayText.Replace("Grade ", "").Split('-')[0].Trim();

                string query = "SELECT id FROM grade WHERE grade_level_number = @gradeName AND section = @section";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@gradeName", gradeName);
                    cmd.Parameters.AddWithValue("@section", section);
                    object result = cmd.ExecuteScalar();
                    if (result != null) return Convert.ToInt32(result);

                    query = "SELECT id FROM grade LIMIT 1";
                    using (MySqlCommand cmd2 = new MySqlCommand(query, conn))
                    {
                        result = cmd2.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 1;
                    }
                }
            }
        }

        private string SaveProfileImage()
        {
            if (pbStudentPhoto.Image == null) return null;

            try
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "ProfileImages");
                if (!Directory.Exists(imagesFolder)) Directory.CreateDirectory(imagesFolder);

                string safeId = label19.Text.Replace("/", "_").Replace("\\", "_");
                string fileName = $"student_{safeId}_{DateTime.Now:yyyyMMddHHmmss}.jpg";
                string filePath = Path.Combine(imagesFolder, fileName);

                pbStudentPhoto.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                return $"ProfileImages/{fileName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save profile image: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private void ClearAllFields()
        {
            txtStudentName.Clear();
            textBox1.Clear();
            NIC.Clear();
            textBox2.Clear();
            pbStudentPhoto.Image = null;
            dtpDOB.Value = DateTime.Now.AddYears(-10);
            cmbSection.SelectedIndex = 0;

            textBox6.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox5.Clear();
            comboBox2.SelectedIndex = 0;
            textBox8.Clear();
            comboBox1.SelectedIndex = 0;
            textBox3.Clear();

            if (comboBox3.Items.Count > 0) comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;

            label19.Text = "";
            button3.Enabled = true;
            button4.Visible = false;

            tabControl1.SelectedIndex = 0;
            txtStudentName.Focus();
        }

        private void NIC_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NIC.Text) && NIC.Text.Length >= 10)
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT COUNT(*) FROM users WHERE nic = @nic";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nic", NIC.Text.Trim());
                            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                            { MessageBox.Show("This NIC is already registered!", "Duplicate NIC", MessageBoxButtons.OK, MessageBoxIcon.Warning); NIC.Focus(); }
                        }
                    }
                    catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
                }
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox7.Text) && textBox7.Text.Contains("@"))
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT COUNT(*) FROM users WHERE email = @email";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@email", textBox7.Text.Trim());
                            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                            { MessageBox.Show("This Email is already registered!", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox7.Focus(); }
                        }
                    }
                    catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
                }
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox5.Text) && textBox5.Text.Length >= 10)
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT COUNT(*) FROM users WHERE nic = @nic";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nic", textBox5.Text.Trim());
                            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                            { MessageBox.Show("This NIC is already registered!", "Duplicate NIC", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox5.Focus(); }
                        }
                    }
                    catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}