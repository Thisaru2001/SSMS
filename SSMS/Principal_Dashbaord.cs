using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SSMS
{
    public partial class Principal_Dashbaord : Form
    {
        // ✅ 1. ADD THIS FIELD TO STORE THE USER ID
        private int _loggedInUserId;

        // ✅ 2. FIX THE CONSTRUCTOR TO ACCEPT USER ID
        public Principal_Dashbaord(int userId)
        {
            InitializeComponent();
            _loggedInUserId = userId; // Save the ID
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void Principal_Dashbaord_Load(object sender, EventArgs e)
        {
            LoadDateAndTime();
            LoadDashboardStats();
            LoadStudentList();
            LoadLatestNotice();
            LoadProfileImage();
            LoadName();
        }

        private void LoadName()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT firstname, lastname FROM users WHERE id = @uid";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", _loggedInUserId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string firstName = reader["firstname"].ToString();
                                string lastName = reader["lastname"].ToString();

                                // Update the prinName label with a welcome message
                                prinName.Text = $"{firstName} {lastName}";
                            }
                            else
                            {
                                prinName.Text = "Principal";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    prinName.Text = "Welcome, Principal";
                    MessageBox.Show("Error loading name: " + ex.Message);
                }
            }
        }

        private void LoadDateAndTime()
        {
            // Uncomment this if you want a live clock:
            // label9.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:mm:ss tt");
        }

        private void LoadDashboardStats()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    // 1. Total Active Students
                    string studentQuery = "SELECT COUNT(*) FROM student WHERE status = 'Active'";
                    using (MySqlCommand cmd = new MySqlCommand(studentQuery, conn))
                    {
                        totalStudents.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 2. Total Active Teachers
                    string teacherQuery = "SELECT COUNT(*) FROM users WHERE role = 'teacher' AND is_active = 1";
                    using (MySqlCommand cmd = new MySqlCommand(teacherQuery, conn))
                    {
                        totalTeachers.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 3. Total Classes
                    string classQuery = "SELECT COUNT(*) FROM grade";
                    using (MySqlCommand cmd = new MySqlCommand(classQuery, conn))
                    {
                        label13.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 4. Today's Student Attendance %
                    string studentAttQuery = @"SELECT ROUND((COUNT(CASE WHEN is_present = 1 THEN 1 END) / COUNT(*)) * 100, 0) 
                                             FROM student_attendance WHERE date = CURDATE()";
                    using (MySqlCommand cmd = new MySqlCommand(studentAttQuery, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        label14.Text = (result != DBNull.Value && result != null) ? result.ToString() + "%" : "0%";
                    }

                    // 5. Today's Teacher Attendance %
                    string teacherAttQuery = @"SELECT ROUND((COUNT(CASE WHEN status = 'Present' THEN 1 END) / COUNT(*)) * 100, 0) 
                                             FROM teacher_attendance WHERE date = CURDATE()";
                    using (MySqlCommand cmd = new MySqlCommand(teacherAttQuery, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        label15.Text = (result != DBNull.Value && result != null) ? result.ToString() + "%" : "0%";
                    }
                }
                catch (Exception)
                {
                    // Fallback if tables are empty
                    totalStudents.Text = "0";
                    totalTeachers.Text = "0";
                    label13.Text = "0";
                    label14.Text = "0%";
                    label15.Text = "0%";
                }
            }
        }

        private void LoadStudentList()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT 
                                        s.student_id AS 'Student ID',
                                        u.firstname AS 'First Name',
                                        u.lastname AS 'Last Name',
                                        CONCAT('Grade ', g.grade_level_number) AS 'Grade',
                                        g.section AS 'Section',
                                        u.email AS 'Email',
                                        u.phone AS 'Phone'
                                     FROM student s
                                     INNER JOIN users u ON s.users_id = u.id
                                     INNER JOIN grade g ON s.grade_id = g.id
                                     WHERE s.status = 'Active'
                                     ORDER BY g.grade_level_number, g.section, u.firstname";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        dgvStudentList.DataSource = dt;
                        dgvStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading student list: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadLatestNotice()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT body, notice_date, u.firstname 
                                     FROM notice n
                                     INNER JOIN users u ON n.posted_by = u.id
                                     ORDER BY n.created_at DESC 
                                     LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label10.Text = reader["body"].ToString();

                            string postedDate = Convert.ToDateTime(reader["notice_date"]).ToString("dd MMM yyyy");
                            string postedBy = reader["firstname"].ToString();

                            // ✅ UNCOMMENTED THIS LINE SO IT SHOWS THE DATE AND WHO POSTED IT
                            label9.Text = $"Posted on {postedDate} by {postedBy}";
                        }
                        else
                        {
                            label10.Text = "No recent notices available.";
                            label9.Text = "No notices posted yet."; // ✅ UNCOMMENTED
                        }
                    }
                }
                catch (Exception ex)
                {
                    label10.Text = "Error loading notice.";
                    MessageBox.Show("Error loading notice: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ✅ 4. ADD THIS METHOD TO LOAD THE PROFILE IMAGE
        private void LoadProfileImage()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT image_path FROM users WHERE id = @uid";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", _loggedInUserId);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            string imagePath = result.ToString();

                            // 1. Fix slashes
                            imagePath = imagePath.Replace('/', '\\');

                            // 2. FORCE IT TO LOOK INSIDE THE ACTUAL EXE FOLDER
                            string fullPath = System.IO.Path.Combine(Application.StartupPath, imagePath);

                            if (System.IO.File.Exists(fullPath))
                            {
                                pictureBox1.Image = Image.FromFile(fullPath);
                                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                            else
                            {
                                // This will show you the exact, full, real path it is failing on
                                MessageBox.Show($"ERROR: Application searched here:\n\n{fullPath}\n\nBut the file was NOT found.\n\nCheck if your filename has a typo (like 'teaher' instead of 'teacher').");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading profile image: " + ex.Message);
                }
            }
        }

        // ==================== BUTTON EVENTS ====================
        private void btnTeacherRegister_Click(object sender, EventArgs e)
        {
            teacher_register teacher_Register = new teacher_register();
            teacher_Register.Show();
        }

        private void btnStudentRegister_Click(object sender, EventArgs e)
        {
            Student_register student_Register = new Student_register();
            student_Register.Show();
        }

        private void btnTimeTableCreation_Click(object sender, EventArgs e)
        {
            timetable timeTable = new timetable();
            timeTable.Show();
        }

        private void btnTeacherAttendance_Click(object sender, EventArgs e)
        {
            // Open your Teacher Attendance form here
        }

        private void btnNoticeCreation_Click(object sender, EventArgs e)
        {
            // Open your Notice Creation form here
        }

        private void btnViewNotices_Click(object sender, EventArgs e)
        {
            LoadLatestNotice(); // Refresh the notice when this button is clicked
            // Open your Notice List form here
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            // Open Principal Profile form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Signin loginForm = new Signin();
                loginForm.Show();
                this.Hide();
            }
        }

        // ==================== EMPTY EVENT HANDLERS ====================
        private void label7_Click(object sender, EventArgs e) { }
        private void lblName_Click(object sender, EventArgs e) { }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}