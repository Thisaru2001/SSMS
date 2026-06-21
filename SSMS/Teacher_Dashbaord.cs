using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SSMS
{
    public partial class Teacher_Dashbaord : Form
    {

        private int _loggedInUserId;


        public Teacher_Dashbaord(int userId)
        {
            InitializeComponent();
            _loggedInUserId = userId;
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void Teacher_Dashbaord_Load(object sender, EventArgs e)
        {
            LoadTeacherProfile();      // Loads Name into lblName and Image into pictureBox1
            LoadDashboardStats();      // Loads Totals into lblTotalStudents, lblPresent, etc.
            LoadTodayClasses();        // Loads DataGridView
            LoadLatestNotice();        // Loads notice into lblNotice1
        }

        private void LoadTeacherProfile()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    // 1. Get Name and Image
                    string nameQuery = "SELECT firstname, lastname, image_path FROM users WHERE id = @uid";
                    using (MySqlCommand cmd = new MySqlCommand(nameQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", _loggedInUserId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string firstName = reader["firstname"].ToString();
                                string lastName = reader["lastname"].ToString();
                                string imagePath = reader["image_path"]?.ToString();

                                // ✅ UPDATE LABEL
                                lblName.Text = $"{firstName} {lastName}";

                                // ✅ DEBUG: Show us the ID and Image path it found
                                MessageBox.Show($"Logged in as ID: {_loggedInUserId}\nName: {firstName} {lastName}\nImage Path: {imagePath ?? "NULL"}");

                                // ✅ LOAD IMAGE
                                if (!string.IsNullOrEmpty(imagePath))
                                {
                                    imagePath = imagePath.Replace('/', '\\');
                                    string fullPath = Path.Combine(Application.StartupPath, imagePath);

                                    if (File.Exists(fullPath))
                                    {
                                        pictureBox1.Image = Image.FromFile(fullPath);
                                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Image file not found here:\n{fullPath}");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Database returned NULL for image_path.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No user found with ID: {_loggedInUserId}!");
                                lblName.Text = "Teacher";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblName.Text = "Teacher";
                    MessageBox.Show("Error loading profile: " + ex.Message);
                }
            }
        }

        // ==========================================
        // 2. LOAD STATS (Total Students, Present, Absent)
        // ==========================================
        private void LoadDashboardStats()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    // 1. Total Students registered in the school
                    string totalQuery = "SELECT COUNT(*) FROM student WHERE status = 'Active'";
                    using (MySqlCommand cmd = new MySqlCommand(totalQuery, conn))
                    {
                        lblTotalStudents.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 2. Present Today (Student Attendance)
                    string presentQuery = "SELECT COUNT(*) FROM student_attendance WHERE date = CURDATE() AND is_present = 1";
                    using (MySqlCommand cmd = new MySqlCommand(presentQuery, conn))
                    {
                        lblPresent.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 3. Absent Today (Student Attendance)
                    string absentQuery = "SELECT COUNT(*) FROM student_attendance WHERE date = CURDATE() AND is_present = 0";
                    using (MySqlCommand cmd = new MySqlCommand(absentQuery, conn))
                    {
                        lblAbsent.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 4. Total Notices
                    string noticeQuery = "SELECT COUNT(*) FROM notice";
                    using (MySqlCommand cmd = new MySqlCommand(noticeQuery, conn))
                    {
                        lblNotices.Text = cmd.ExecuteScalar().ToString();
                    }
                }
                catch (Exception)
                {
                    // Fallback to 0 if no data exists
                    lblTotalStudents.Text = "0";
                    lblPresent.Text = "0";
                    lblAbsent.Text = "0";
                    lblNotices.Text = "0";
                }
            }
        }

        // ==========================================
        // 3. LOAD TODAY'S CLASSES (DataGridView)
        // ==========================================
        private void LoadTodayClasses()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    // Get today's day name (e.g., "Monday")
                    string today = DateTime.Now.DayOfWeek.ToString();

                    // Query to get classes taught by this teacher today
                    string query = @"SELECT 
                                        CONCAT('Grade ', g.grade_level_number, ' - ', g.section) AS 'Class',
                                        sub.subject_name AS 'Subject',
                                        CONCAT(DATE_FORMAT(tt.start_time, '%h:%i %p'), ' - ', DATE_FORMAT(tt.end_time, '%h:%i %p')) AS 'Time',
                                        tt.room AS 'Room'
                                     FROM timetable tt
                                     INNER JOIN subject sub ON tt.subject_id = sub.id
                                     INNER JOIN grade g ON tt.grade_id = g.id
                                     INNER JOIN teacher t ON tt.teacher_id = t.id
                                     WHERE t.users_id = @uid 
                                     AND tt.day_of_week = @day
                                     ORDER BY tt.start_time";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", _loggedInUserId);
                        cmd.Parameters.AddWithValue("@day", today);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dataGridViewclasses.DataSource = dt;

                            // Make the DataGridView look pretty
                            dataGridViewclasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dataGridViewclasses.RowHeadersVisible = false;
                            dataGridViewclasses.BackgroundColor = Color.White;
                            dataGridViewclasses.DefaultCellStyle.Font = new Font("Segoe UI", 10.5F);
                            dataGridViewclasses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                            dataGridViewclasses.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
                            dataGridViewclasses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                            dataGridViewclasses.EnableHeadersVisualStyles = false;
                            dataGridViewclasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading today's classes: " + ex.Message);
                }
            }
        }

        // ==========================================
        // 4. LOAD LATEST NOTICE
        // ==========================================
        private void LoadLatestNotice()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT title, body, notice_date FROM notice ORDER BY created_at DESC LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string title = reader["title"].ToString();
                            string body = reader["body"].ToString();
                            string date = Convert.ToDateTime(reader["notice_date"]).ToString("dd MMM yyyy");

                            // Put Title + Body into lblNotice1 (Your designer uses this label)
                            lblNotice1.Text = $"{title}\n\n{body}";

                            // Put Date into lblNotice2
                            lblNotice2.Text = $"Posted on {date}";
                        }
                        else
                        {
                            lblNotice1.Text = "No recent notices.";
                            lblNotice2.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblNotice1.Text = "Error loading notice.";
                    MessageBox.Show("Error loading notice: " + ex.Message);
                }
            }
        }

        // ==========================================
        // 5. BUTTON CLICK EVENTS
        // ==========================================
        private void btnLogout_Click(object sender, EventArgs e)
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

        private void btnStudentAttendance_Click(object sender, EventArgs e) { }
        private void btnMarks_Click(object sender, EventArgs e) { }
        private void btnUpdate_Click(object sender, EventArgs e) { }
        private void btnEsamShedule_Click(object sender, EventArgs e) { }
        private void btnProfile_Click(object sender, EventArgs e) { }
        private void btnNoticeCreate_Click(object sender, EventArgs e) { }
        private void btnViewAllNotices_Click(object sender, EventArgs e)
        {
            LoadLatestNotice(); // Refresh notice when clicked
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}