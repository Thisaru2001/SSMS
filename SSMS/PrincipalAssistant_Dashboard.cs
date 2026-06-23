using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SSMS
{
    public partial class PrincipalAssistant_Dashboard : Form
    {
        
        private int _loggedInUserId;

        
        public PrincipalAssistant_Dashboard(int userId)
        {
            InitializeComponent();
            _loggedInUserId = userId; 
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void PrincipalAssistant_Dashboard_Load(object sender, EventArgs e)
        {
            LoadDateAndTime();
            LoadDashboardStats();
            LoadStudentList();
            LoadLatestNotice();
            LoadProfileImage();
            LoadName();
            btnTeacherRegister.Visible = false;
            btnStudentRegister.Visible = false;
            btnTeacherAttendance.Visible = false;
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
            
            
        }

        private void LoadDashboardStats()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    
                    string studentQuery = "SELECT COUNT(*) FROM student WHERE status = 'Active'";
                    using (MySqlCommand cmd = new MySqlCommand(studentQuery, conn))
                    {
                        totalStudents.Text = cmd.ExecuteScalar().ToString();
                    }

                    
                    string teacherQuery = "SELECT COUNT(*) FROM users WHERE role = 'teacher' AND is_active = 1";
                    using (MySqlCommand cmd = new MySqlCommand(teacherQuery, conn))
                    {
                        totalTeachers.Text = cmd.ExecuteScalar().ToString();
                    }

                    
                    string classQuery = "SELECT COUNT(*) FROM grade";
                    using (MySqlCommand cmd = new MySqlCommand(classQuery, conn))
                    {
                        label13.Text = cmd.ExecuteScalar().ToString();
                    }

                    
                    string studentAttQuery = @"SELECT ROUND((COUNT(CASE WHEN is_present = 1 THEN 1 END) / COUNT(*)) * 100, 0) 
                                             FROM student_attendance WHERE date = CURDATE()";
                    using (MySqlCommand cmd = new MySqlCommand(studentAttQuery, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        label14.Text = (result != DBNull.Value && result != null) ? result.ToString() + "%" : "0%";
                    }

                    
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
                                CONCAT('Grade ', g.grade_level_number) AS 'Grade',
                                g.section AS 'Section'
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
                        if (dgvStudentList.Rows.Count > 1)
                        {
                            dgvStudentList.ClearSelection();
                            dgvStudentList.Rows[1].Selected = true;   
                            dgvStudentList.CurrentCell = dgvStudentList.Rows[1].Cells[0];
                        }
                        dgvStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        

                        dgvStudentList.RowHeadersVisible = false;
                        dgvStudentList.BackgroundColor = Color.White;
                        dgvStudentList.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 240);
                        dgvStudentList.RowsDefaultCellStyle.BackColor = Color.White;
                        dgvStudentList.RowsDefaultCellStyle.ForeColor = Color.Black;
                        dgvStudentList.DefaultCellStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                        dgvStudentList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 135, 80);
                        dgvStudentList.DefaultCellStyle.SelectionForeColor = Color.White;

                        
                        dgvStudentList.EnableHeadersVisualStyles = false;

                        dgvStudentList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 135, 80);
                        dgvStudentList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        dgvStudentList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                        dgvStudentList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvStudentList.ColumnHeadersHeight = 45;

                        dgvStudentList.RowTemplate.Height = 40;
                        dgvStudentList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                        dgvStudentList.GridColor = Color.FromArgb(220, 220, 220);
                        dgvStudentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                            label10.Text = $"{noticeTitle}\n\n{noticeBody}".Trim();

                            string postedDate = Convert.ToDateTime(reader["notice_date"]).ToString("dd MMM yyyy");
                            string postedBy = reader["firstname"].ToString();

                            
                            label9.Text = $"Posted on {postedDate} by {postedBy}";
                        }
                        else
                        {
                            label10.Text = "No recent notices available.";
                            label9.Text = "No notices posted yet."; 
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

                            
                            imagePath = imagePath.Replace('/', '\\');

                            
                            string fullPath = System.IO.Path.Combine(Application.StartupPath, imagePath);

                            if (System.IO.File.Exists(fullPath))
                            {
                                pictureBox1.Image = Image.FromFile(fullPath);
                                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                            else
                            {
                                
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

        
        private void btnTeacherRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Access Denied", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStudentRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Access Denied", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTimeTableCreation_Click(object sender, EventArgs e)
        {
            timetable timeTable = new timetable();
            timeTable.ShowDialog();
        }

        private void btnTeacherAttendance_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Access Denied", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNoticeCreation_Click(object sender, EventArgs e)
        {
            pNoticeCreate pn = new pNoticeCreate(_loggedInUserId);
            pn.ShowDialog();
            LoadLatestNotice(); 
        }

        private void btnViewNotices_Click(object sender, EventArgs e)
        {
            LoadLatestNotice(); 
            
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            profile profileForm = new profile(_loggedInUserId, "principal_assistant");
            profileForm.ShowDialog();
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

        
        private void label7_Click(object sender, EventArgs e) { }
        private void lblName_Click(object sender, EventArgs e) { }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }

        private void dgvStudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}