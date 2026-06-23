using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SSMS
{
    public partial class pNoticeCreate : Form
    {
        private int _userId;

        public pNoticeCreate(int userId)
        {
            InitializeComponent();
            _userId = userId;
            this.Load += PNoticeCreate_Load;
            btnPublish.Click += BtnPublish_Click;

            chkAll.CheckedChanged += ChkAll_CheckedChanged;
            chkTeachers.CheckedChanged += ChkOthers_CheckedChanged;
            chkStudents.CheckedChanged += ChkOthers_CheckedChanged;
        }

        private void PNoticeCreate_Load(object sender, EventArgs e)
        {
            try
            {
                string query = $"SELECT firstname, lastname FROM users WHERE id = {_userId}";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    lblPName.Text = dt.Rows[0]["firstname"].ToString() + " " + dt.Rows[0]["lastname"].ToString();
                }
            }
            catch (Exception)
            {
                lblPName.Text = "Principal";
            }
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                chkTeachers.Checked = false;
                chkStudents.Checked = false;
            }
        }

        private void ChkOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTeachers.Checked || chkStudents.Checked)
            {
                chkAll.Checked = false;
            }
        }

        private void BtnPublish_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string content = rtbContent.Text.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("Please enter both a title and content for the notice.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetGroup = "All";
            if (chkTeachers.Checked && chkStudents.Checked) targetGroup = "All";
            else if (chkTeachers.Checked) targetGroup = "Teachers";
            else if (chkStudents.Checked) targetGroup = "Students";
            else if (chkAll.Checked) targetGroup = "All";
            else
            {
                MessageBox.Show("Please select a target group for the notice.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                EnvironmentConfig.Load();
                using (MySqlConnection conn = new MySqlConnection(EnvironmentConfig.GetConnectionString()))
                {
                    conn.Open();
                    string query = "INSERT INTO notice (title, body, target_group, posted_by, notice_date) VALUES (@Title, @Body, @TargetGroup, @PostedBy, @NoticeDate)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Body", content);
                        cmd.Parameters.AddWithValue("@TargetGroup", targetGroup);
                        cmd.Parameters.AddWithValue("@PostedBy", _userId);
                        cmd.Parameters.AddWithValue("@NoticeDate", DateTime.Now.Date);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Notice published successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPublish_Click_1(object sender, EventArgs e)
        {

        }
    }
}
