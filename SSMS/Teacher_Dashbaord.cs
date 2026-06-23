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
        public Teacher_Dashbaord()
        {
            
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void Teacher_Dashbaord_Load(object sender, EventArgs e)
        {
            LoadTeacherProfile();      
            LoadDashboardStats();      
            LoadTodayClasses();        
            LoadLatestNotice();        
        }

        private void LoadTeacherProfile()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    
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

                                
                                string fullName = $"{firstName} {lastName}";
                                
                                if (fullName.Length > 14)
                                {
                                    lblName.Font = new Font(lblName.Font.FontFamily, 13F, FontStyle.Bold);
                                }
                                lblName.Text = fullName;
                                
                                label1.Text = $"Welcome Back {fullName}";
                                label3.Text = ""; 
                                panel13.Visible = false; 

                                
                                if (!string.IsNullOrEmpty(imagePath))
                                {
                                    imagePath = imagePath.Replace('/', '\\');
                                    string fullPath = Path.Combine(Application.StartupPath, imagePath);

                                    if (File.Exists(fullPath))
                                    {
                                        pictureBox1.Image = Image.FromFile(fullPath);
                                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No user found with ID: {_loggedInUserId}!");
                                lblName.Text = "Teacher";
                                label3.Text = "Teacher";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblName.Text = "Teacher";
                    label3.Text = "Teacher";
                    MessageBox.Show("Error loading profile: " + ex.Message);
                }
            }
        }

        
        
        
        private void LoadDashboardStats()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string today = DateTime.Now.DayOfWeek.ToString();

                    
                    string totalQuery = @"
                        SELECT COUNT(DISTINCT s.id)
                        FROM student s
                        WHERE s.status = 'Active' AND s.grade_id IN (
                            SELECT tt.grade_id 
                            FROM timetable tt
                            INNER JOIN teacher t ON tt.teacher_id = t.id
                            WHERE t.users_id = @uid AND tt.day_of_week = @day
                            
                            UNION
                            
                            SELECT rt.grade_id
                            FROM relief_timetable rt
                            INNER JOIN teacher t ON rt.relief_teacher_id = t.id
                            WHERE t.users_id = @uid AND rt.relief_date = CURDATE()
                        )";

                    using (MySqlCommand cmd = new MySqlCommand(totalQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", _loggedInUserId);
                        cmd.Parameters.AddWithValue("@day", today);
                        lblTotalStudents.Text = cmd.ExecuteScalar().ToString();
                    }

                    
                    string presentQuery = @"
                        SELECT COUNT(DISTINCT sa.student_id)
                        FROM student_attendance sa
                        INNER JOIN student s ON sa.student_id = s.id
                        WHERE sa.date = CURDATE() AND sa.is_present = 1
                          AND s.grade_id IN (
                              SELECT tt.grade_id 
                              FROM timetable tt
                              INNER JOIN teacher t ON tt.teacher_id = t.id
                              WHERE t.users_id = @uid AND tt.day_of_week = @day
                              
                              UNION
                              
                              SELECT rt.grade_id
                              FROM relief_timetable rt
                              INNER JOIN teacher t ON rt.relief_teacher_id = t.id
                              WHERE t.users_id = @uid AND rt.relief_date = CURDATE()
                          )";

                    using (MySqlCommand cmd = new MySqlCommand(presentQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", _loggedInUserId);
                        cmd.Parameters.AddWithValue("@day", today);
                        lblPresent.Text = cmd.ExecuteScalar().ToString();
                    }

                    
                    string weeklyQuery = @"
                        SELECT 
                            SUM(CASE WHEN sa.is_present = 1 THEN 1 ELSE 0 END) AS PresentCount,
                            COUNT(*) AS TotalCount
                        FROM student_attendance sa
                        INNER JOIN student s ON sa.student_id = s.id
                        WHERE sa.date >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)
                          AND s.grade_id IN (
                              SELECT DISTINCT tt.grade_id 
                              FROM timetable tt 
                              INNER JOIN teacher t ON tt.teacher_id = t.id 
                              WHERE t.users_id = @uid
                          )";

                    using (MySqlCommand cmd = new MySqlCommand(weeklyQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", _loggedInUserId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int presentCount = reader["PresentCount"] != DBNull.Value ? Convert.ToInt32(reader["PresentCount"]) : 0;
                                int totalCount = reader["TotalCount"] != DBNull.Value ? Convert.ToInt32(reader["TotalCount"]) : 0;
                                
                                if (totalCount > 0)
                                {
                                    double rate = (double)presentCount / totalCount * 100;
                                    lblAbsent.Text = $"{rate:0.0}%";
                                }
                                else
                                {
                                    lblAbsent.Text = "0%";
                                }
                            }
                        }
                    }
                    
                    
                    label7.Text = "Weekly Attendance";

                    
                    string noticeQuery = "SELECT COUNT(*) FROM notice WHERE DATE(created_at) = CURDATE()";
                    using (MySqlCommand cmd = new MySqlCommand(noticeQuery, conn))
                    {
                        lblNotices.Text = cmd.ExecuteScalar().ToString();
                    }
                    label8.Text = "Today Notices";
                }
                catch (Exception)
                {
                    
                    lblTotalStudents.Text = "0";
                    lblPresent.Text = "0";
                    lblAbsent.Text = "0%";
                    lblNotices.Text = "0";
                }
            }
        }

        
        
        
        private void LoadTodayClasses()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    
                    string today = DateTime.Now.DayOfWeek.ToString();

                    
                    string query = @"SELECT Class, Subject, Time, Room, Type FROM (
                                        SELECT 
                                            CONCAT('Grade ', g.grade_level_number, ' - ', g.section) AS 'Class',
                                            sub.subject_name AS 'Subject',
                                            CONCAT(DATE_FORMAT(tt.start_time, '%h:%i %p'), ' - ', DATE_FORMAT(tt.end_time, '%h:%i %p')) AS 'Time',
                                            tt.room AS 'Room',
                                            'Regular' AS 'Type',
                                            tt.start_time AS SortTime
                                         FROM timetable tt
                                         INNER JOIN subject sub ON tt.subject_id = sub.id
                                         INNER JOIN grade g ON tt.grade_id = g.id
                                         INNER JOIN teacher t ON tt.teacher_id = t.id
                                         WHERE t.users_id = @uid 
                                         AND tt.day_of_week = @day
                                         
                                         UNION ALL
                                         
                                         SELECT 
                                            CONCAT('Grade ', g.grade_level_number, ' - ', g.section) AS 'Class',
                                            sub.subject_name AS 'Subject',
                                            CONCAT(DATE_FORMAT(rt.start_time, '%h:%i %p'), ' - ', DATE_FORMAT(rt.end_time, '%h:%i %p')) AS 'Time',
                                            rt.room AS 'Room',
                                            'Relief' AS 'Type',
                                            rt.start_time AS SortTime
                                         FROM relief_timetable rt
                                         INNER JOIN subject sub ON rt.subject_id = sub.id
                                         INNER JOIN grade g ON rt.grade_id = g.id
                                         INNER JOIN teacher t ON rt.relief_teacher_id = t.id
                                         WHERE t.users_id = @uid 
                                         AND rt.relief_date = CURDATE()
                                     ) AS combined
                                     ORDER BY SortTime";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", _loggedInUserId);
                        cmd.Parameters.AddWithValue("@day", today);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dataGridViewclasses.DataSource = dt;

                            
                            dataGridViewclasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            
                            
                            if (dataGridViewclasses.Columns.Contains("Time"))
                            {
                                dataGridViewclasses.Columns["Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            }
                            if (dataGridViewclasses.Columns.Contains("Room"))
                            {
                                dataGridViewclasses.Columns["Room"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            }
                            
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

        
        
        
        private void LoadLatestNotice()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT title, body, notice_date, u.firstname 
                                     FROM notice n
                                     INNER JOIN users u ON n.posted_by = u.id
                                     ORDER BY n.created_at DESC 
                                     LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string noticeTitle = reader["title"].ToString();
                            string noticeBody = reader["body"].ToString();
                            
                            
                            label9.Text = $"{noticeTitle}\n\n{noticeBody}".Trim();
                            label9.MaximumSize = new Size(290, 0); 
                            label9.AutoSize = true;

                            
                            DateTime dateObj = Convert.ToDateTime(reader["notice_date"]);
                            string formattedDate = dateObj.ToString("dd MMMM yyyy");
                            string authorName = reader["firstname"].ToString();

                            
                            label12.Text = $"Posted on {formattedDate} by {authorName}";
                            
                            
                            lblNotice1.Text = "";
                            lblNotice2.Text = "";
                        }
                        else
                        {
                            label9.Text = "No recent notices.";
                            label12.Text = "";
                            lblNotice1.Text = "";
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

        private void btnStudentAttendance_Click(object sender, EventArgs e) {
            studentAttendance st = new studentAttendance(_loggedInUserId);
            st.Show();

        }
        private void btnMarks_Click(object sender, EventArgs e) 
        { 
            addmarks am = new addmarks(_loggedInUserId);
            am.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e) 
        { 
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter Student ID to update (e.g., ST/2026/001):", "Update Student", "");
            if (!string.IsNullOrWhiteSpace(input))
            {
                Student_register sr = new Student_register(input.Trim(), editMode: true);
                sr.Show();
            }
        }

        private void btnEsamShedule_Click(object sender, EventArgs e) 
        { 
            examSchedule es = new examSchedule();
            es.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            profile profileForm = new profile(_loggedInUserId, "teacher");
            profileForm.ShowDialog();
        }

        private void btnNoticeCreate_Click(object sender, EventArgs e) 
        { 
            noticeCreate nc = new noticeCreate(_loggedInUserId);
            nc.ShowDialog();
        }
        private void btnViewAllNotices_Click(object sender, EventArgs e)
        {
            LoadLatestNotice(); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Teacher_Dashbaord_Load_1(object sender, EventArgs e)
        {

        }
    }
}